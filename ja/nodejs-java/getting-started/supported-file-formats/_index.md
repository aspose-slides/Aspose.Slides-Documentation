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
この表は Aspose.Slides for Node.js via Java が読み込みおよび保存できるファイル形式を示します:

|**フォーマット**|**説明**|**読み込み**|**保存**|**備考**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 プレゼンテーション|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 テンプレート|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 スライドショー|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint プレゼンテーション|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint テンプレート|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint スライドショー|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint マクロ対応プレゼンテーション|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint マクロ対応スライドショー|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint マクロ対応テンプレート|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument プレゼンテーション|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument プレゼンテーションテンプレート|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|タグ画像ファイル形式| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|拡張メタファイル形式| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|ポータブルドキュメント形式|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML ペーパー仕様| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Joint Photographic Experts Group| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|ポータブルネットワークグラフィックス| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|デバイス非依存ビットマップ| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|スケーラブルベクターグラフィックス| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|スモールウェブフォーマット| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|ハイパーテキストマークアップ言語|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|拡張アプリケーションマークアップ言語| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML プレゼンテーション| |{{< emoticons/tick >}}| |

## **FAQ**

**PDF/A および PDF/UA などのアーカイブおよびアクセシビリティ基準を満たす PDF へのプレゼンテーションの保存はできますか？**

はい。Aspose.Slides は、PDF/A-2a、PDF/A-2b、PDF/A-2u、PDF/A-3a、PDF/A-3b、PDF/UA などの準拠レベルで PDF へエクスポートすることをサポートしています。これは、[compliance](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setcompliance/) 設定を使用した [PDF export options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) で設定できます。

**PDF へエクスポートする際にフォント埋め込みをサポートし、埋め込む内容を細かく制御できますか？**

はい。フォントを完全に埋め込むかサブセット（使用されたグリフのみ）にするかを制御でき、一般的なシステムフォントの扱いを指定し、ASCII テキストの動作を設定できます。これらは [PDF export options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) で設定できます。

**ファイルを実際に読み込む前に、パスワードで保護されているかどうかを検出できますか？**

はい。[factory-based inspection API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/) を使用して、プレゼンテーション ファイルがパスワードで保護されているかどうかを、ファイルを完全に開くことなく問い合わせることができます。

**フォントのフォールバック機構やカスタムフォントのサポートはありますか？**

はい。ライブラリはカスタムフォントの [loading](/slides/ja/nodejs-java/custom-font/) と [embedding](/slides/ja/nodejs-java/embedded-font/) をサポートし、レンダリングや変換時に欠落したグリフを防止するためのフォント [fallback rules](/slides/ja/nodejs-java/fallback-font/) を提供します。

**スライドを XPS にエクスポートできますか？また、XPS 出力を調整するオプションはありますか？**

はい。[Export to XPS](/slides/ja/nodejs-java/convert-powerpoint-to-xps/) がサポートされており、XPS ドキュメントの品質や内容を制御するために関連する [save options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/) を調整できます。