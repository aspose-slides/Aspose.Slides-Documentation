---
title: セキュリティ
type: docs
weight: 160
url: /ja/java/security/
keywords:
- セキュリティ
- 依存関係
- サードパーティ コンポーネント
- Maven
- JAR 署名
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java がプレゼンテーションをどのように処理するか、プロジェクトの依存関係に何が追加されるか、JAR ファイルの検証方法、および含まれるサードパーティ コンポーネントを確認します。"
---
## **はじめに**

この記事では、Aspose.Slides for Java を使用するアプリケーションのセキュリティレビューで通常必要となる情報をまとめています。ライブラリがプレゼンテーションをどのように処理するか、プロジェクトの依存関係に何が追加されるか、JAR ファイルが Aspose からのものかを確認する方法、そして JAR ファイルに含まれるサードパーティ コンポーネントについて説明します。

## **Aspose.Slides のセキュリティ**

Aspose は製品開発においてベストプラクティスを適用しています。

* Aspose.Slides for Java はプレゼンテーションの作成、変更、変換に使用されます。プレゼンテーション内のスクリプトを実行することはありません。Aspose.Slides はプレゼンテーションの構造を解析し、オブジェクトモデルを通じてコードから操作できるようにします。
* Aspose.Slides はリモートコードを実行せずにドキュメントを解析・解釈するライブラリとして機能します。すべての Aspose 製品はユーザーのマシン上で実行され、データを Aspose に送信しません。唯一の例外は [metered licensing](/slides/ja/java/metered-licensing/) で、使用した場合は API 利用情報のみが処理されます。
* Aspose コンポーネントは通常のアプリケーションと同じユーザーコンテキストで実行されます。そのため、システムの重要リソースに対するリスクはありません。また、Aspose コンポーネントがドキュメントを開く際にマクロが自動的に実行されることはありません。

## **Maven 依存関係**

Aspose.Slides for Java の Maven アーティファクト `com.aspose:aspose-slides` は依存関係を宣言していません。POM ファイルにはアーティファクト自身の座標だけが記載されています。プロジェクトに追加すると、Maven はこの JAR ファイル一つだけを取得し、他のものは追加しません。プロジェクトが解決するすべてのアーティファクト（トランジティブ依存関係を含む）を一覧表示するには、プロジェクトフォルダーで次のコマンドを実行します。

```bash
mvn dependency:tree
```

[Installation](/slides/ja/java/installation/) のプロジェクトでは、出力に Aspose.Slides が唯一の依存関係として表示されます。

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **JAR ファイルの検証**

Aspose は JAR ファイルに署名しています。署名を確認するには、JAR ファイルがあるフォルダーで JDK の `jarsigner` ツールを実行します。

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

署名が有効でファイルが変更されていない場合、コマンドは `jar verified.` と出力します。このメッセージには署名者の名前は表示されません。Aspose が署名したことを確認するには、`-verbose` と `-certs` オプションを付けて実行し、署名者の証明書が `CN=ASPOSE PTY LTD` であることを確認してください。Maven が JAR ファイルをダウンロードするときは、リポジトリが提供する SHA-1 チェックサムも自動的に検証されます。

## **サードパーティ コンポーネント**

Aspose.Slides for Java にはサードパーティ コンポーネントからのコードとデータが含まれています。これらは JAR ファイル内に組み込まれており、別個の Maven アーティファクトではないため、`mvn dependency:tree` などの Maven 依存関係を読むツールには表示されません。JAR ファイルには *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf* という通知ファイルが含まれており、そこにコンポーネントとライセンスが一覧化されています。

| コンポーネント | 通知に記載されたライセンス |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | MIT-style license |
| Mono | MIT license; some parts under other licenses that the notice lists |
| RSWOP.ICM color profile | Microsoft license terms |
| sRGB_v4_ICC_preference.icc color profile | ICC permission to use, copy, and distribute the unchanged file |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

通知を JAR ファイルから抽出するには、JAR ファイルがあるフォルダーで JDK の `jar` ツールを実行します。

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **FAQ**

**Aspose.Slides for Java は外部パッケージを使用しますか？**

[Maven Dependencies](#maven-dependencies) に示されているように Maven 依存関係はありませんが、[Third-Party Components](#third-party-components) に列挙されたサードパーティ コンポーネントが JAR に含まれています。セキュリティレビューでは JAR ファイル本体とこれらのコンポーネントの両方を対象にしてください。

**Aspose.Slides for Java はネットワークアクセスが必要ですか？**

いいえ。プレゼンテーションの作成、保存、レンダリングはネットワーク接続がなくても実行できます。Aspose へデータを送信する唯一の機能は [metered licensing](/slides/ja/java/metered-licensing/) で、API 利用状況を報告します。

**Aspose.Slides for Java にネイティブコードは含まれますか？**

いいえ。JAR ファイルには Java クラスとリソースだけが含まれ、ネイティブ ライブラリは追加されません。Linux 環境でフォントをサポートするには、Java ランタイムが fontconfig ライブラリと OS のフォントに依存します。詳細は [System Requirements](/slides/ja/java/system-requirements/#linux) を参照してください。