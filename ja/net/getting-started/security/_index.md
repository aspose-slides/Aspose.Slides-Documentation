---
title: セキュリティ
type: docs
weight: 160
url: /ja/net/security/
keywords:
- セキュリティ
- 依存関係
- サードパーティ コンポーネント
- NuGet
- 脆弱性スキャン
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET がプレゼンテーションを処理する方法、対象フレームワークごとに依存する NuGet パッケージ、および含まれるサードパーティ コンポーネントについて確認します。"
---
## **Aspose.Slides のセキュリティ**

Aspose は製品開発時にベストプラクティスを適用しています。

* Aspose.Slides for .NET はプレゼンテーションを操作し、他の形式に変換するために使用されます。プレゼンテーション内のスクリプトは実行しません。Aspose.Slides はプレゼンテーションの構造を解析し、エンドユーザーのコードがオブジェクトモデルを便利に操作できるようにします。
* Aspose.Slides はリモートコードを実行せずにドキュメントを解析・解釈するライブラリとして機能します。すべての Aspose 製品はお客様のマシン上で実行されます。データは Aspose に送信されません。唯一の例外は[従量課金ライセンス](https://purchase.aspose.com/faqs/licensing/metered)：使用する場合は API 使用情報のみが処理されます。
* Aspose コンポーネントは通常のアプリケーションと同じユーザーコンテキストで実行されます。そのため、Aspose コンポーネントは重要なシステムリソースにリスクをもたらしません。また、Aspose コンポーネントがドキュメントを開く際にマクロが自動的に実行されることはありません。
* Microsoft Office パッケージに固有または関連するリスクは Aspose コンポーネントには適用されないため、Aspose 製品は非常に安全です。

## **NuGet の依存関係**

Aspose.Slides for .NET は Microsoft が NuGet に公開しているパッケージに依存しています。依存関係はパッケージと対象フレームワークによって異なります。

| パッケージ | 対象フレームワーク | 依存関係 |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

NuGet の [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) および [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) ページの **Dependencies** セクションには、各リリースごとの各依存関係の最低バージョンが記載されています。

Aspose.Slides をプロジェクトに追加すると、NuGet はこれらのパッケージの依存関係も復元します。トランジティブ依存関係を含むプロジェクトが復元するすべてのパッケージを一覧表示するには、プロジェクト フォルダーで次のコマンドを実行してください：

```bash
dotnet list package --include-transitive
```

同じパッケージセットを既知の脆弱性と比較してチェックするには、次を実行します：

```bash
dotnet list package --vulnerable --include-transitive
```

NuGet パッケージを監査する他の方法については、[Auditing package dependencies for security vulnerabilities](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages) を参照してください。

## **サードパーティ コンポーネント**

Aspose.Slides はサードパーティのオープンソース コンポーネントのコードを含んでいます。これらは製品の一部であり、別個の NuGet パッケージではありません。そのため、NuGet 依存関係のみを読み取るツールでは表示されません。両方のパッケージには *thirdpartylicenses.Aspose.Slides.for.NET.pdf* ファイルが含まれており、コンポーネントとそれらのライセンスが記載されています：

| コンポーネント | 通知に記載されたライセンス |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **FAQ**

**Aspose のコードに対する脆弱性を監視するシステムは何ですか？**

私たちは Aspose.Slides のすべてのリリースに対して静的コード解析を実行しています。Aspose.Slides のコードが OWASP Top 10 をクリアしていることを示すセキュリティ レポートを提供できます。

**Aspose.Slides は外部パッケージを使用していますか？**

はい。Microsoft が提供する NuGet パッケージ（[NuGet の依存関係](#nuget-dependencies) に記載）に依存しており、[サードパーティ コンポーネント](#third-party-components) に記載されたサードパーティ コンポーネントも含まれています。セキュリティ評価には両方を含め、`dotnet list package --vulnerable --include-transitive` を使用してプロジェクトが復元する NuGet パッケージを確認してください。