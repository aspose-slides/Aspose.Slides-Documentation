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
description: "Aspose.Slides for .NET 6 を設定して、最新のクロスプラットフォーム C# アプリケーションで PowerPoint PPT、PPTX、ODP プレゼンテーションを作成、編集、変換します。"
---

## はじめに

.NET6 のサポートは [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0) から導入されました。このサポートの特徴は、.NET6 が Linux で System.Drawing.Common をサポートしなくなったことです（[breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)）。Slides はこのグラフィカルサブシステムを C++ コンポーネントとして独自に実装しています。

Aspose.Slides for .NET は、以下のプラットフォームで GDI/libgdiplus への依存なしで動作します:
* Windows
* Linux

_MacOS_ のサポートは進行中です。

## AWS と Azure で Slides for .NET6 を使用する

.NET6 は、クラウド（AWS、Azure、その他のクラウドソリューション）で使用される Aspose.Slides の推奨バージョンです。

以前は、Linux ホスト上で Aspose.Slides を使用する際、追加の依存関係（libgdiplus）をインストールする必要があり、[AWS Lambda](https://aws.amazon.com/lambda) を使用する場合など、しばしば不便または実用的でないことがありました。Slides for .NET6 を使用すれば、これらの依存関係は不要となり、デプロイが格段に容易になります。

もう一つの考慮点は、Windows ホスト上のクラウドソリューションで Aspose.Slides を使用した際に発生した問題です。例えば、[Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) にはプロセスに制限があり、PDF エクスポート処理中に問題が生じます（[こちら](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks) 参照）。Aspose.Slides for .NET6 の使用により、この問題は解決されます。

## System.Drawing.Common パッケージと Slides for .NET6 クラスの使用 (CS0433: 型が Slides と System.Drawing.Common の両方に存在するエラー)

プロジェクトによっては、System.Drawing と Slides for .NET6 の両方の依存関係を使用する必要があることがあります（例: .NET6 プロジェクトが他のパッケージに依存し、そのパッケージが System.Drawing に依存している場合）。このような場合、以下のようなエラーが発生することがあります:

* CS0433: 型 'Image' が 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' と 'System.Drawing.Common, Version=6.0.0.0' の両方に存在します
* CS0433: 型 'Graphics' が 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' と 'System.Drawing.Common, Version=6.0.0.0' の両方に存在します

この場合、Aspose.Slides（バージョン 24.8 未満）に対して [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) を使用できます:
1) プロジェクトの依存関係から Aspose.Slides アセンブリを選択し、**Properties** をクリックします。  
   ![Aspose Slides パッケージのプロパティ](package_properties.png)
2) エイリアスを設定します（例: "Slides"）。  
   ![Aspose Slides エイリアス](set_alias.png)

これにより、既定で System.Drawing.Common の型が使用されます。Aspose.Slides の型が必要な箇所では、外部アセンブリのエイリアスを指定してください。
```c#
extern alias Slides;
using Slides::Aspose.Slides;
```


完全な例:
```c#
extern alias Slides;
using Slides::Aspise.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```


バージョン 24.8 以降、System.Drawing に依存する旧式のパブリック API は削除されました。上記のコード例に関しては、以下のようにスライド画像を取得できます。
```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```

新しい API の詳細は、[Modern API](/net/modern-api/) に記載されています。