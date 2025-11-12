---
title: PythonでPowerPointプレゼンテーションをXPSに変換
linktitle: PowerPointからXPSへ
type: docs
weight: 70
url: /ja/python-net/convert-powerpoint-to-xps/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- PowerPointからXPSへ
- プレゼンテーションからXPSへ
- PPTからXPSへ
- PPTXからXPSへ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して、PythonでPowerPoint PPT/PPTX を高品質でプラットフォームに依存しない XPS に変換します。ステップバイステップのガイドとサンプルコードをご覧ください。"
---

## **XPSについて**

Microsoft は [XPS](https://docs.fileformat.com/page-description-language/xps/) を [PDF](https://docs.fileformat.com/pdf/) の代替として開発しました。PDF に非常に似たファイルを出力することでコンテンツを印刷できるようにします。XPS フォーマットは XML に基づいています。XPS ファイルのレイアウトや構造は、すべての OS とプリンターで同じままです。

## Microsoft XPS フォーマットを使用すべきとき

{{% alert color="primary" %}} 

Aspose.Slides が PPT または PPTX プレゼンテーションを XPS フォーマットに変換する方法を確認するには、[この無料オンラインコンバーター アプリ](https://products.aspose.app/slides/conversion)をご利用ください。

{{% /alert %}} 

ストレージコストを削減したい場合、Microsoft PowerPoint プレゼンテーションを XPS フォーマットに変換できます。この方法により、ドキュメントの保存、共有、印刷がより簡単になります。

Microsoft は Windows（Windows 10 でも）における XPS の強力なサポートを継続的に実装しているため、ファイルをこの形式で保存することを検討したいでしょう。Windows 8.1、Windows 8、Windows 7、Windows Vista を使用している場合、特定の操作において XPS が最適な選択肢になることがあります。

- **Windows 8** は XPS ファイルに OXPS（Open XPS）フォーマットを使用します。OXPS は元の XPS フォーマットの標準化バージョンです。Windows 8 は PDF ファイルよりも XPS ファイルのサポートが優れています。  
  - **XPS**：組み込みの XPS ビューア/リーダーと XPS への印刷機能が利用可能。  
  - **PDF**：PDF リーダーは利用可能だが、PDF への印刷機能はなし。  

- **Windows 7 と Windows Vista** は元の XPS フォーマットを使用します。これらの OS も PDF より XPS のサポートが優れています。  
  - **XPS**：組み込みの XPS ビューアと XPS への印刷機能が利用可能。  
  - **PDF**：PDF リーダーなし。PDF への印刷機能なし。  

|<p>**入力 PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力 XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft は最終的に Windows 10 の「Print to PDF」機能により PDF への印刷操作をサポートしました。それ以前はユーザーは XPS フォーマットを介してドキュメントを印刷することが想定されていました。

## Aspose.Slides を使用した XPS 変換

[**Aspose.Slides**](https://products.aspose.com/slides/python-net/) for .NET では、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスが提供する [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) メソッドを使用して、プレゼンテーション全体を XPS ドキュメントに変換できます。

プレゼンテーションを XPS に変換する際は、以下のいずれかの設定で保存する必要があります。

- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/) を使用しない場合）
- カスタム設定（[**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/) を使用する場合）

### **デフォルト設定を使用したプレゼンテーションの XPS 変換**

この Python のサンプルコードは、標準設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示します。

```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation オブジェクトを生成
pres = slides.Presentation("Convert_XPS.pptx")

# プレゼンテーションを XPS ドキュメントとして保存
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```

### **カスタム設定を使用したプレゼンテーションの XPS 変換**

このサンプルコードは、Python でカスタム設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示します。

```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation オブジェクトを生成
pres = slides.Presentation("Convert_XPS_Options.pptx")

# TiffOptions クラスのインスタンスを生成
options = slides.export.XpsOptions()

# メタファイルを PNG として保存
options.save_metafiles_as_png = True

# プレゼンテーションを XPS ドキュメントとして保存
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **よくある質問**

**ファイルではなくストリームに XPS を保存できますか？**

はい—Aspose.Slides はストリームへの直接エクスポートをサポートしており、Web API やサーバー側パイプライン、ファイルシステムに触れずに XPS を送信したいシナリオに最適です。

**非表示スライドは XPS に含まれますか、除外できますか？**

デフォルトでは、通常の（表示されている）スライドのみがレンダリングされます。保存前に [エクスポート設定](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/) で [非表示スライドの表示/非表示](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) を設定することで、出力に含めるページを正確に制御できます。