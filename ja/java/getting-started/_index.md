---
title: はじめに
type: docs
weight: 10
url: /ja/java/getting-started/
keywords:
- はじめに
- システム要件
- インストール
- 最初のプレゼンテーション
- Maven
- PPT 処理
- PPTX 処理
- ODP 処理
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "新しい Java プロジェクトから Aspose.Slides を使用した最初の保存されたプレゼンテーションまでの手順: 要件を確認し、Aspose の Maven リポジトリからライブラリを追加し、最初のプログラムを実行し、共通タスクを続行します。"
---
## **概要**

以下の4つのステップを順番に実行してください。各ステップはやることを示し、詳細記事へのリンクがあります。評価、ライセンス、サポートはステップの後で説明します。

## **ステップ 1: システム要件の確認**

Aspose.Slides for Java は単一の JAR ファイルでネイティブコードを含まないため、サポートされている Java ランタイムがあれば任意の OS で実行できます。[System Requirements](/slides/ja/java/system-requirements/) にはサポートされている OS と Java バージョンが記載されています。次のステップで使用するプロジェクトとコマンドは JDK 11 以降が必要で、Maven を利用する場合は[Apache Maven](https://maven.apache.org/install.html) が必要です。

## **ステップ 2: ライブラリをプロジェクトに追加**

Aspose.Slides for Java は Aspose 独自の Maven リポジトリに公開されており、Maven Central にはありません。以下のいずれかの方法を選択してください。

- Maven を使用する場合: *pom.xml* にリポジトリ `https://releases.aspose.com/java/repo/` を宣言し、`com.aspose:aspose-slides` 依存関係に `jdk16` classifier を追加します。
- Maven を使用しない場合: リポジトリから名前が *-jdk16.jar* で終わる JAR ファイルをダウンロードし、クラスパスに配置します。

Linux では fontconfig ライブラリと少なくとも1つのフォントをインストールする必要があります。これらがないと「Fontconfig head is null, check your fonts or fonts configuration」というエラーでプレゼンテーションの保存に失敗します。

[Installation](/slides/ja/java/installation/) には *pom.xml* エントリ、JAR のダウンロード方法、Linux 用コマンドが記載されています。

## **ステップ 3: 最初のプレゼンテーションを作成**

[Aspose.Slides for Java のホームページにあるクイックスタート](/slides/ja/java/#your-first-presentation) は、完全な Maven プロジェクトです。*pom.xml* と、スライドにクラウド形状とテキストを追加し、PPTX ファイルとして保存するプログラムが含まれます。`mvn compile exec:java` で実行します。[Create Presentations](/slides/ja/java/create-presentation/) では同じプログラムをステップバイステップで説明しています。既存のプレゼンテーションを開いて別形式で保存する方法は、[Open Presentations](/slides/ja/java/open-presentation/) と [Save Presentations](/slides/ja/java/save-presentation/) を参照してください。

## **ステップ 4: 共通タスクを続行**

- [プレゼンテーションを開く](/slides/ja/java/open-presentation/)
- [プレゼンテーションを保存](/slides/ja/java/save-presentation/)
- [プレゼンテーションを PDF に変換](/slides/ja/java/convert-powerpoint-to-pdf/)
- [スライドを画像としてレンダリング](/slides/ja/java/convert-slide/)
- [プレゼンテーションのテキストを編集](/slides/ja/java/manage-text/)
- [スライド要素別のサンプル](/slides/ja/java/examples/)

## **評価とライセンス**

ライセンスなしでは Aspose.Slides は評価モードで動作し、保存するすべてのスライドに透かしが付加され、コードがプレゼンテーションから読み取るテキストが切り詰められます。

- [Aspose.Slides の評価](/slides/ja/java/evaluate-aspose-slides/) では評価の制限と一時ライセンスの取得方法を説明しています。
- [ライセンス](/slides/ja/java/licensing/) ではファイルまたはストリームからライセンスを適用する方法を示しています。
- [従量課金ライセンス](/slides/ja/java/metered-licensing/) では使用量に応じて課金されるライセンスについて説明します。
- [サポートされているファイル形式](/slides/ja/java/supported-file-formats/) では Aspose.Slides が読み書きできる形式を一覧で示しています。

## **ヘルプを得る**

[テクニカルサポート](/slides/ja/java/technical-support/) では、[無料サポートフォーラム](https://forum.aspose.com/c/slides/ja/11)で質問する方法と、問題報告時に含めるべき情報を説明しています。

## **FAQ**

**Microsoft PowerPoint はインストールが必要ですか？**

いいえ。Aspose.Slides はプレゼンテーションファイルを自ら読み書きするため PowerPoint を使用せず、サーバーや Linux 上でも実行可能です。

**なぜ Maven が Aspose.Slides for Java を見つけられないのですか？**

このライブラリは Maven Central にはありません。*pom.xml* に Aspose のリポジトリを宣言してください。方法は[Installation](/slides/ja/java/installation/) に記載されています。Maven はそこからライブラリをダウンロードします。

**`jdk16` classifier はライブラリが Java 16 が必要という意味ですか？**

いいえ。classifier は Java SE 用ビルドを選択するためのもので、もう一つは Android 用です。同じビルドは JDK 21 など現在の JDK でも動作します。