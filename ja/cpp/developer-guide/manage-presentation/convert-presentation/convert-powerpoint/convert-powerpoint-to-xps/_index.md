---
title: C++ で PowerPoint プレゼンテーションを XPS に変換する
linktitle: PowerPoint から XPS へ
type: docs
weight: 70
url: /ja/cpp/convert-powerpoint-to-xps
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint から XPS へ
- プレゼンテーションから XPS へ
- スライドから XPS へ
- PPT から XPS へ
- PPTX から XPS へ
- PPT を XPS として保存
- PPTX を XPS として保存
- PPT を XPS にエクスポート
- PPTX を XPS にエクスポート
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ で PowerPoint の PPT/PPTX を高品質かつプラットフォームに依存しない XPS に変換します。ステップバイステップのガイドとサンプルコードをご覧ください。"
---

## **XPS について**
Microsoft は [XPS](https://docs.fileformat.com/page-description-language/xps/) を [PDF](https://docs.fileformat.com/pdf/) の代替として開発しました。PDF に非常に似たファイルを出力することでコンテンツを印刷できます。XPS フォーマットは XML をベースにしています。XPS ファイルのレイアウトまたは構造は、すべてのオペレーティングシステムやプリンターで同じままです。

## **Microsoft XPS フォーマットを使用すべきとき**
{{% alert color="primary" %}} 
Aspose.Slides が PPT または PPTX プレゼンテーションを XPS フォーマットに変換する方法を見るには、[この無料オンラインコンバータ アプリ](https://products.aspose.app/slides/conversion) をチェックしてください。 
{{% /alert %}} 

ストレージコストを削減したい場合は、Microsoft PowerPoint プレゼンテーションを XPS フォーマットに変換できます。これにより、文書の保存、共有、印刷がより簡単になります。

Microsoft は Windows（Windows 10 でも）で XPS の強力なサポートを継続的に実装しているため、このフォーマットでファイルを保存することを検討した方がよいでしょう。Windows 8.1、Windows 8、Windows 7、Windows Vista を使用している場合、特定の操作において XPS が実際に最適なオプションになることがあります。

- **Windows 8** は XPS ファイルに OXPS（Open XPS）フォーマットを使用します。OXPS は元の XPS フォーマットの標準化バージョンです。Windows 8 は PDF ファイルよりも XPS ファイルのサポートが優れています。
  - **XPS:** 組み込みの XPS ビューア/リーダーと XPS への印刷機能が利用可能です。
  - **PDF:** PDF リーダーは利用可能ですが、PDF への印刷機能はありません。

- **Windows 7 と Windows Vista** は元の XPS フォーマットを使用します。これらの OS も PDF より XPS ファイルのサポートが優れています。
  - **XPS:** 組み込みの XPS ビューアと XPS への印刷機能が利用可能です。
  - **PDF:** PDF リーダーがありません。PDF への印刷機能もありません。

|<p>**入力 PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**出力 XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft は最終的に Windows 10 の「Print to PDF」機能を通じて PDF への印刷操作のサポートを実装しました。それ以前は、ユーザーは XPS フォーマットを介して文書を印刷することが想定されていました。

## **Aspose.Slides を使用した XPS 変換**
C++ 用の [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) では、[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスが提供する [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) メソッドを使用して、プレゼンテーション全体を XPS ドキュメントに変換できます。

プレゼンテーションを XPS に変換する際は、次のいずれかの設定でプレゼンテーションを保存する必要があります。
- デフォルト設定（[**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options) を使用しない）
- カスタム設定（[**XPSOptions**] を使用）

### **デフォルト設定でプレゼンテーションを XPS に変換**
以下の C++ サンプルコードは、標準設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています。
``` cpp
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// プレゼンテーションを XPS ドキュメントに保存します
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **カスタム設定でプレゼンテーションを XPS に変換**
以下の C++ サンプルコードは、カスタム設定を使用してプレゼンテーションを XPS ドキュメントに変換する方法を示しています。
``` cpp
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// TiffOptions クラスをインスタンス化します
auto options = System::MakeObject<XpsOptions>();

// メタファイルを PNG として保存します
options->set_SaveMetafilesAsPng(true);

// プレゼンテーションを XPS ドキュメントに保存します
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```


## **よくある質問**
**ファイルではなくストリームに XPS を保存できますか？**  
はい。Aspose.Slides はストリームへ直接エクスポートでき、Web API やサーバー側パイプライン、またはファイルシステムに触れずに XPS を送信したいあらゆるシナリオに最適です。

**非表示スライドは XPS に含まれますか？除外できますか？**  
デフォルトでは、通常の（表示されている）スライドのみがレンダリングされます。[エクスポート設定](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/) を使用して、XPS に保存する前に非表示スライドを [含めるか除外するか](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) できます。これにより、出力は意図したページだけを正確に含みます。