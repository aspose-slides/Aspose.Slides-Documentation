---
title: .NET6 サポート
type: docs
weight: 235
url: /ja/net/net6/
keywords: 
- .NET 6
- クラウド
- AWS
- Azure
description: ".NET6 サポート"
---

## はじめに

[Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0) から、.NET6 のサポートが実装されました。このサポートの特異点は、.NET6 が Linux 用の System.Drawing.Common のサポートを終了したことです（[破壊的変更](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)）そして、Slides はこのグラフィカルサブシステムを C++ コンポーネントとして独自に実装しています。

Aspose.Slides for .NET は、以下のプラットフォームで GDI/libgdiplus への依存なしに動作します：
* Windows
* Linux

_MacOS_ のサポートは進行中です。

## AWS と Azure での .NET6 用 Slides の使用

.NET6 は、クラウド（AWS、Azure、またはその他のクラウドソリューション）で使用される Aspose.Slides の推奨バージョンです。

以前は、Aspose.Slides を Linux ホストで使用する際に、追加の依存関係（libgdiplus）をインストールする必要があり、これはしばしば不便または非実用的でした（例： [AWS Lambda](https://aws.amazon.com/lambda) を使用する場合）。Slides for .NET6 では、これらの依存関係がもはや必要なく、展開がはるかに簡単になります。

もう1つの考慮事項は、Aspose.Slides を Windows ホストのクラウドソリューションで使用した際に発生した問題です。例えば、[Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) にはプロセスに制限があり、PDF エクスポート操作中に問題が発生します（[こちら](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)を参照）。Aspose.Slides for .NET6 の使用は、この問題を解決します。

## System.Drawing.Common パッケージと Slides for .NET6 クラスの使用 (CS0433: 型が Slides と System.Drawing.Common の両方に存在するエラー)

時には、プロジェクト内で System.Drawing と Slides for .NET6 の両方の依存関係を使用する必要があります（例： .NET6 プロジェクトが他のパッケージに依存し、それらがさらに System.Drawing に依存する場合）。これにより、次のような複雑なエラーが発生することがあります：

* CS0433: 型 'Image' は 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' と 'System.Drawing.Common, Version=6.0.0.0' の両方に存在します
* CS0433: 型 'Graphics' は 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' と 'System.Drawing.Common, Version=6.0.0.0' の両方に存在します

この場合、Aspose.Slides（バージョン 24.8 未満）について [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) を使用できます：
1) プロジェクトの依存関係から Aspose.Slides アセンブリを選択し、**プロパティ**をクリックします。
  ![Aspose Slides パッケージのプロパティ](package_properties.png)
2) エイリアスを設定します（例えば、「Slides」）。
  ![Aspose Slides エイリアス](set_alias.png)

これで、System.Drawing.Common からの型がデフォルトで使用されます。Aspose.Slides の型が必要な場所で外部アセンブリエイリアスを指定する必要があります。

```c#
extern alias Slides;
using Slides::Aspose.Slides;
```

完全な例：

```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```

バージョン 24.8 以降、System.Drawing に依存する非推奨の公開 API は削除されました。上記のコード例に関しては、スライド画像を次のように取得できます。

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
新しい API の詳細については、[Modern API](/net/modern-api/)を参照してください。