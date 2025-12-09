---
title: .NET 6 サポート
type: docs
weight: 235
url: /ja/net/net6/
keywords:
- .NET 6 サポート
- クラウド ソリューション
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 6 を構成して、モダンでクロスプラットフォームな C# アプリケーションで PowerPoint の PPT、PPTX、ODP プレゼンテーションを作成、編集、変換します。"
---

## はじめに

[ Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0) から、.NET6 のサポートが実装されました。このサポートの特徴は、.NET6 が Linux 向けに System.Drawing.Common をサポートしなくなったことです（[breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)）。Slides はこのグラフィカルサブシステムを C++ コンポーネントとして自前で実装しています。

Aspose.Slides for .NET は、以下の環境で GDI/libgdiplus に依存せずに動作します。
* Windows
* Linux

_MacOS_ サポートは進行中です。

## .NET6 用 Slides を AWS と Azure で使用する

.NET6 は、クラウド（AWS、Azure、その他のクラウドソリューション）で使用する Aspose.Slides の推奨バージョンです。

従来、Linux ホストで Aspose.Slides を使用する際は、追加の依存関係（libgdiplus）をインストールする必要があり、たとえば [AWS Lambda](https://aws.amazon.com/lambda) を使用する場合など、煩雑または実用的でないことがありました。.NET6 用 Slides ではこれらの依存関係が不要になるため、デプロイが格段に容易になります。

もう一つの考慮点は、Windows ホストのクラウドソリューションで Aspose.Slides を使用した際に発生した問題です。たとえば [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) ではプロセスに制限があり、PDF エクスポート操作中に問題が生じます（[このページ](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks) 参照）。.NET6 用 Aspose.Slides の使用により、この問題は解決されます。

## System.Drawing.Common パッケージと .NET6 用 Slides クラスの併用（CS0433: The type exists in both Slides and System.Drawing.Common エラー）

プロジェクトで System.Drawing と .NET6 用 Slides の両方の依存関係を使用する必要がある場合（例: .NET6 プロジェクトが他のパッケージに依存し、そのパッケージが System.Drawing に依存している場合）では、次のようなエラーが発生することがあります。

* CS0433: The type 'Image' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0
* CS0433: The type 'Graphics' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0

この場合、Aspose.Slides（バージョン 24.8 未満）に対して [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) を使用できます。
1) プロジェクトの依存関係から Aspose.Slides アセンブリを選択し、**Properties** をクリックします。  
   ![Aspose Slides パッケージ プロパティ](package_properties.png)
2) エイリアスを設定します（例: "Slides"）。  
   ![Aspose Slides エイリアス](set_alias.png)

これにより、System.Drawing.Common の型がデフォルトで使用されます。Aspose.Slides の型が必要な場所で外部アセンブリエイリアスを指定してください。
```c#
extern alias Slides;
using Slides::Asprose.Slides;
```


完全な例:
```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```


バージョン 24.8 からは、System.Drawing に依存する非推奨のパブリック API が削除されました。上記のコード例に関しては、以下のようにスライド画像を取得できます。
```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```

新しい API の詳細は [Modern API](/net/modern-api/) に記載されています。  
---
title: .NET 6 サポート
type: docs
weight: 235
url: /ja/net/net6/
keywords:
- .NET 6 サポート
- クラウド ソリューション
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 6 を構成して、モダンでクロスプラットフォームな C# アプリケーションで PowerPoint の PPT、PPTX、ODP プレゼンテーションを作成、編集、変換します。"
---
