---
title: サポートされているファイル形式
type: docs
weight: 30
url: /ja/net/supported-file-formats/
---

## **サポートされている Microsoft PowerPoint のバージョン**
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
この表は Aspose.Slides for .NET がロードおよび保存できるファイル形式を示しています。

|**フォーマット**|**説明**|**ロード**|**保存**|**備考**|
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
|[TIFF](https://docs.fileformat.com/image/tiff/)|タグ画像ファイル形式| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|拡張メタファイル形式| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|ポータブルドキュメント形式|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML ペーパー仕様| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Joint Photographic Experts Group| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|ポータブルネットワークグラフィックス| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|デバイス非依存ビットマップ| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|スケーラブルベクタ画像| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|スモールウェブフォーマット| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|ハイパーテキストマークアップ言語|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|拡張アプリケーションマークアップ言語| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML プレゼンテーション| |{{< emoticons/tick >}}| |

## **FAQ**

**アーカイブおよびアクセシビリティ標準（PDF/A および PDF/UA）に準拠した PDF にプレゼンテーションを保存できますか？**

はい。Aspose.Slides は PDF のエクスポート時に PDF/A‑2a、PDF/A‑2b、PDF/A‑2u、PDF/A‑3a、PDF/A‑3b、そして PDF/UA への準拠レベルを [compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) 設定で指定できるようサポートしています。

**PDF にエクスポートする際にフォント埋め込みをサポートし、埋め込む内容を細かく制御できますか？**

はい。フォントを完全に埋め込むかサブセット化（使用されたグリフのみ）するかを制御でき、一般的なシステムフォントの扱いを指定し、ASCII テキストの動作を [PDF export options](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) で構成できます。

**実際にロードする前にファイルがパスワード保護されているか検出できますか？**

はい。[factory‑based inspection API](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/) を使用すると、プレゼンテーション ファイルを完全に開かずにパスワード保護の有無を照会できます。

**フォントのフォールバック機構やカスタムフォントのサポートはありますか？**

はい。ライブラリはカスタム フォントの [loading](/slides/ja/net/custom-font/) と [embedding](/slides/ja/net/embedded-font/) をサポートし、レンダリングや変換時に欠落したグリフを防止するフォント [fallback rules](/slides/ja/net/fallback-font/) を提供します。

**スライドを XPS にエクスポートできますか？また、XPS 出力を調整するオプションはありますか？**

はい。[Export to XPS](/slides/ja/net/convert-powerpoint-to-xps/) がサポートされており、[save options](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) を調整して XPS ドキュメントの品質や内容を制御できます。