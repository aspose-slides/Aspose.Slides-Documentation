---
title: サポートされているファイル形式
type: docs
weight: 30
url: /ja/nodejs-java/supported-file-formats/
---

## **サポートされている Microsoft PowerPoint バージョン**
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

## **サポートされているファイル形式**
この表は、Aspose.Slides for Node.js via Java がロードおよび保存できるファイル形式を示しています。

|**形式**|**説明**|**ロード**|**保存**|**備考**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 プレゼンテーション|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 テンプレート|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 スライドショー|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint プレゼンテーション|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint テンプレート|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX ](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint スライドショー|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint マクロ対応プレゼンテーション|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint マクロ対応スライドショー|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint マクロ対応テンプレート|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument プレゼンテーション|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument プレゼンテーションテンプレート|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tag Image File Format| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile Format| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Joint Photographic Experts Group| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|Device Independent Bitmap| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML プレゼンテーション| |{{< emoticons/tick >}}| |

## **よくある質問**

**アーカイブおよびアクセシビリティ標準 (PDF/A と PDF/UA) に適合した PDF にプレゼンテーションを保存できますか？**

Yes. Aspose.Slides supports exporting to PDF with compliance levels such as PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, as well as PDF/UA through the [compliance](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setcompliance/) setting in [PDF export options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/).

**PDF へエクスポートするときにフォント埋め込みをサポートし、埋め込む内容を細かく制御できますか？**

Yes. You can control whether fonts are fully embedded or subsetted (only used glyphs), specify how common system fonts are treated, and configure behavior for ASCII text through [PDF export options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/).

**実際にロードする前にファイルがパスワード保護されているか検出できますか？**

Yes. Using the [factory-based inspection API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/), you can query a presentation file to determine if it is password-protected without opening it fully.

**フォントフォールバック機構やカスタムフォントのサポートはありますか？**

Yes. The library supports [loading](/slides/ja/nodejs-java/custom-font/) and [embedding](/slides/ja/nodejs-java/embedded-font/) custom fonts and provides font [fallback rules](/slides/ja/nodejs-java/fallback-font/) to prevent missing glyphs during rendering and conversion.

**スライドを XPS にエクスポートできますか？また、XPS 出力を調整するオプションはありますか？**

Yes. [Export to XPS](/slides/ja/nodejs-java/convert-powerpoint-to-xps/) is supported, and you can adjust relevant [save options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/) to control the output quality and content of the XPS document.