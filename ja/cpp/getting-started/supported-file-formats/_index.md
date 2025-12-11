---
title: サポートされているファイル形式
type: docs
weight: 20
url: /ja/cpp/supported-file-formats/
keywords:
- ファイル形式
- サポート形式
- PPT
- POT
- PPS
- PPTX
- POTX
- PPSX
- PPTM
- PPSM
- POTM
- ODP
- FODP
- OTP
- TIFF
- EMF
- PDF
- XPS
- JPEG
- PNG
- GIF
- BMP
- SVG
- SWF
- HTML
- XAML
- MD
- XML
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ が開くこと・保存すること・変換できるすべてのファイル形式を紹介します — PPT、PPTX、ODP など、インポート/エクスポートのサポート情報を明確に示します。"
---

## **サポート対象 Microsoft PowerPoint バージョン**
- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for MAC
- Office 365

## **サポート対象ファイル形式**
This table contains the file formats that Aspose.Slides for С++ can load and save:

|**形式**|**説明**|**読み込み**|**保存**|**備考**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 Presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 Template|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 Show|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint Presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint Template|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSX ](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint Show|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint Macro-Enabled Presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint Macro-Enabled Show|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint Macro-Enabled Template|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument Presentation|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument Presentation Template|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tag Image File Format||{{< emoticons/tick >}}||
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile Format||{{< emoticons/tick >}}||
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification||{{< emoticons/tick >}}||
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Joint Photographic Experts Group||{{< emoticons/tick >}}||
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics||{{< emoticons/tick >}}||
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format||{{< emoticons/tick >}}||
|[BMP](https://docs.fileformat.com/image/bmp/)|Device Independent Bitmap||{{< emoticons/tick >}}||
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics||{{< emoticons/tick >}}||
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format||{{< emoticons/tick >}}||
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language||{{< emoticons/tick >}}||
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown||{{< emoticons/tick >}}|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML Presentation||{{< emoticons/tick >}}|

## **よくある質問**

**アーカイブおよびアクセシビリティ標準（PDF/A と PDF/UA）に準拠した PDF にプレゼンテーションを保存できますか？**

はい。Aspose.Slides は、[compliance](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_compliance/) 設定を使用する [PDF export options](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) により、PDF/A-2a、PDF/A-2b、PDF/A-2u、PDF/A-3a、PDF/A-3b などの準拠レベルおよび PDF/UA をエクスポートでサポートしています。

**PDF にエクスポートする際にフォント埋め込みをサポートしており、埋め込む内容を細かく制御できますか？**

はい。フォントを完全に埋め込むかサブセット（使用されているグリフのみ）にするかを制御でき、一般的なシステムフォントの取り扱いを指定し、ASCII テキストの動作を [PDF export options](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) で構成できます。

**実際にロードする前にファイルがパスワードで保護されているかを検出できますか？**

はい。[factory-based inspection API](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/) を使用すると、プレゼンテーション ファイルを完全に開かずにパスワード保護されているかどうかを照会できます。

**フォントのフォールバック機構やカスタムフォントのサポートはありますか？**

はい。ライブラリは [loading](/slides/ja/cpp/custom-font/) と [embedding](/slides/ja/cpp/embedded-font/) のカスタムフォントをサポートし、レンダリングや変換時に欠損グリフが発生しないようにするフォント [fallback rules](/slides/ja/cpp/fallback-font/) を提供します。

**スライドを XPS にエクスポートできますか、また XPS 出力を調整するオプションはありますか？**

はい。[Export to XPS](/slides/ja/cpp/convert-powerpoint-to-xps/) がサポートされており、関連する [save options](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/) を調整して XPS ドキュメントの出力品質と内容を制御できます。