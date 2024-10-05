---
title: PowerPointをXPSに変換
type: docs
weight: 70
url: /net/convert-powerpoint-to-xps
keywords: "PowerPointプレゼンテーションの変換, PowerPointからXPS, PPTからXPS, PPTXからXPS, 変換, C#, Csharp, .NET, Aspose.Slides"
description: "C#または.NETでPowerPointプレゼンテーションをXPSに変換します。"
---

## **XPSについて**
マイクロソフトは[XPS](https://docs.fileformat.com/page-description-language/xps/)を[PDF](https://docs.fileformat.com/pdf/)の代替として開発しました。XPSはPDFに非常に似たファイルを出力することによって内容を印刷することを可能にします。XPS形式はXMLに基づいています。XPSファイルのレイアウトまたは構造は、すべてのオペレーティングシステムやプリンターで同じままです。

## Microsoft XPS形式を使用するタイミング

{{% alert color="primary" %}}

Aspose.SlidesがPPTまたはPPTXプレゼンテーションをXPS形式に変換する方法を確認するには、[この無料のオンライン変換アプリ](https://products.aspose.app/slides/conversion)をチェックしてください。

{{% /alert %}}

ストレージコストを削減したい場合は、Microsoft PowerPointプレゼンテーションをXPS形式に変換できます。これにより、ドキュメントの保存、共有、および印刷が容易になります。

MicrosoftはWindows（Windows 10でも）でXPSの強力なサポートを引き続き実装しているため、ファイルをこの形式で保存することを検討するかもしれません。Windows 8.1、Windows 8、Windows 7、Windows Vistaを使用している場合、特定の操作に対してXPSが最良の選択肢となる場合があります。

- **Windows 8**はXPSファイルにOXPS（Open XPS）形式を使用します。OXPSは元のXPS形式の標準化されたバージョンです。Windows 8はPDFファイルよりもXPSファイルに対してより良いサポートを提供します。
  - **XPS:** 組み込みのXPSビューワ/リーダーとXPSへの印刷機能が利用可能です。
  - **PDF**: PDFリーダーは利用可能ですが、PDFへの印刷機能はありません。

- **Windows 7およびWindows Vista**は元のXPS形式を使用します。これらのオペレーティングシステムはPDFよりもXPSファイルに対してより良いサポートを提供します。
  - **XPS**: 組み込みのXPSビューワとXPSへの印刷機能が利用可能です。
  - **PDF**: PDFリーダーはありません。PDFへの印刷機能はありません。

|<p>**入力PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoftは最終的にWindows 10のPDFへの印刷機能を通じてPDFでの印刷操作のサポートを実装しました。それ以前は、ユーザーはXPS形式を通じて文書を印刷することが期待されていました。

## Aspose.SlidesによるXPS変換

[**Aspose.Slides**](https://products.aspose.com/slides/net/) for .NETでは、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスが公開する[**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)メソッドを使用して、プレゼンテーション全体をXPS文書に変換できます。

プレゼンテーションをXPSに変換する際には、次のいずれかの設定を使用してプレゼンテーションを保存する必要があります：

- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions)なし）
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions)あり）

### **デフォルト設定を使用してプレゼンテーションをXPSに変換**

このC#のサンプルコードは、標準設定を使用してプレゼンテーションをXPS文書に変換する方法を示しています：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // プレゼンテーションをXPS文書として保存
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **カスタム設定を使用してプレゼンテーションをXPSに変換**

このサンプルコードは、カスタム設定を使用してプレゼンテーションをXPS文書に変換する方法を示しています：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // TiffOptionsクラスをインスタンス化
    XpsOptions options = new XpsOptions();

    // メタファイルをPNGとして保存
    options.SaveMetafilesAsPng = true;

    // プレゼンテーションをXPS文書として保存
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```