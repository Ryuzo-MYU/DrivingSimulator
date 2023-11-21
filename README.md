# DrivingSimulator
MYU空間情報コンピューティング チームAのコラボレーション用リポジトリ

# 作業環境の構築
1. Unityで新しく、"DrivingSimulator"のプロジェクトを作成する
2. プロジェクトフォルダを開く
3. プロジェクトフォルダの場所でGit bash を開く\
   僕の場合
   ```
   (PCの識別名) MINGW64 ~/(プロジェクトフォルダの親フォルダ)/DriveSimulator (main)
   ```
   Git bash開いてこんな感じに表示されればOK
5. `git init`
6. `git remote add origin (このリポジトリのURL)`
7. `git pull origin main`で、githubに上がっている、Unityプロジェクトの本番環境データを入れることができる\
   すでに作業を進めていた場合、プロジェクトフォルダ内でpullしてしまうと作業内容が消し飛ぶので注意！！！\
   作業内容を一旦プロジェクト外に避難させた方がいい

# 作業方法
1. 作業用フォルダにこのリポジトリをコピーする\
   すでに作業を進めていた場合、プロジェクトフォルダ内でpullしてしまうと作業内容が消し飛ぶので注意！！！

```bash
git pull origin main
```

2. 自分が作業する用のブランチを分ける\
    自分の作業でプロジェクトがぶっ壊れても大丈夫なように、オリジナルから作業用に、プロジェクトを文字通り枝分かれさせます。これを「ブランチを切る」という。

```bash
git branch (新しいブランチ名) #新しいブランチを作成
git checkout (作ったブランチ) #作成したブランチに移動
```

`git branch`と入力すると、今存在しているブランチの一覧をみることができる

こうするとブランチの作成と移動がいっぺんにできる
```bash
git checkout -b (新しいブランチ名)
```

3. 作業内容を自分のブランチにコミットする\
  この辺はcommit -> push の流れと同じ

4. 問題がなければ本番環境に適用する\
  mergeっていうらしい。やったことないので詳細は追って調べます。

# 使い方構想
```
Assets
   ├─3DModels...3Dモデルを入れる。この中で車と環境とかで更に階層分けしてもよし
   └─ Scripts...C#スクリプトを入れる
```
# うろ覚え用語解説
コミット(commit)...大前提としてgitはバージョン管理ツール。commitによって、自分がプロジェクトに対して行った変更を正式に適用できるって感じ。\
プッシュ(push)...リモートリポジトリ(ようはGithub)に、自分の変更を適用させること\
ここには出てないけど、アッド(add)ってのがある。流れとしては
```
git add # プロジェクトの変更を、ローカル環境の「変更適用しますリスト」に追加する
git commit # 〃、ローカル環境の変更に正式に適用する
git push # 〃、オンライン環境に正式に適用する
```
って感じだと思う。(違ってたら容赦なく書き換えオナシャス)

---

Unity Version Controlよりこっちのほうがいいんじゃないかな( )\
勉強しなきゃいけない用語とか、特にgit関連はよくわかんない用語・思想が色々あるけど、ファイルサイズは多分制限ないし、github使えれば現実の業務でも結構役立つし、使って損はないはず
