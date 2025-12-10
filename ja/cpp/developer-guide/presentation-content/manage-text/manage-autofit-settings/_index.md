---
title: C++ の AutoFit でプレゼンテーションを強化する
linktitle: AutoFit 設定
type: docs
weight: 30
url: /ja/cpp/manage-autofit-settings/
keywords:
- テキストボックス
- AutoFit
- 自動調整なし
- テキストをフィット
- テキストを縮小
- テキストを折り返す
- シェイプをリサイズ
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ で AutoFit 設定を管理し、PowerPoint および OpenDocument プレゼンテーションのテキスト表示を最適化して、コンテンツの可読性を向上させる方法を学びます。"
---

デフォルトでは、テキストボックスを追加すると、Microsoft PowerPoint はテキストボックスの **Resize shape to fix text** 設定を使用します。テキストが常にフィットするように、テキストボックスのサイズが自動的に調整されます。

![PowerPoint のテキストボックス](textbox-in-powerpoint.png)

* テキストボックス内のテキストが長くなるまたは大きくなると、PowerPoint はテキストボックスの高さを自動的に拡大して、より多くのテキストを収められるようにします。  
* テキストボックス内のテキストが短くなるまたは小さくなると、PowerPoint はテキストボックスの高さを自動的に縮小して、余分なスペースを取り除きます。

PowerPoint では、テキストボックスの自動調整動作を制御する 4 つの重要なパラメータまたはオプションがあります。

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![PowerPoint の自動調整オプション](autofit-options-powerpoint.png)

Aspose.Slides for C++ は、[TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) クラスのいくつかのメソッドを通じて、プレゼンテーション内のテキストボックスの自動調整動作を制御できる同様のオプションを提供します。

## **Resize a Shape to Fit Text**

テキストが変更された後も常にボックス内に収まるようにしたい場合は、**Resize shape to fix text** オプションを使用する必要があります。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) クラスの [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) プロパティを `Shape` に設定します。

![PowerPoint の常にフィット設定](alwaysfit-setting-powerpoint.png)

この C++ コードは、PowerPoint プレゼンテーションでテキストが常にボックスに収まるように指定する方法を示しています:
```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Shape);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```


テキストが長くなるまたは大きくなると、テキストボックスは自動的に高さが増えてテキスト全体が収まります。テキストが短くなると、その逆が行われます。

## **Do Not Autofit**

テキストの変更にかかわらずテキストボックスまたはシェイプのサイズを保持したい場合は、**Do not Autofit** オプションを使用します。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) クラスの [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) プロパティを `None` に設定します。

![PowerPoint の自動調整なし設定](donotautofit-setting-powerpoint.png)

この C++ コードは、PowerPoint プレゼンテーションでテキストボックスが常に元のサイズを保持するように指定する方法を示しています:
```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::None);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```


テキストがボックスより長くなると、テキストがはみ出します。

## **Shrink Text on Overflow**

テキストがボックスより長くなる場合、**Shrink text on overflow** オプションを使用して、テキストのサイズと間隔を縮小し、ボックス内に収めることができます。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) クラスの [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) プロパティを `Normal` に設定します。

![PowerPoint のオーバーフロー時縮小設定](shrinktextonoverflow-setting-powerpoint.png)

この C++ コードは、PowerPoint プレゼンテーションでテキストがオーバーフローしたときに縮小されるように指定する方法を示しています:
```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Normal);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```


{{% alert title="Info" color="info" %}}
**Shrink text on overflow** オプションは、テキストがボックスより長くなったときにのみ適用されます。  
{{% /alert %}}

## **Wrap Text**

テキストがシェイプの幅を超えたときに、シェイプ内部で折り返したい場合は、**Wrap text in shape** パラメータを使用します。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) クラスの [WrapText](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) プロパティを `true` に設定します。

この C++ コードは、PowerPoint プレゼンテーションで Wrap Text 設定を使用する方法を示しています:
```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_WrapText(NullableBool::True);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 
シェイプの `WrapText` プロパティを `False` に設定すると、テキストがシェイプの幅より長くなった場合に、テキストは単一行でシェイプの境界を超えて表示されます。  
{{% /alert %}}

## **FAQ**

**テキストフレームの内部余白は AutoFit に影響しますか？**

はい。パディング（内部余白）によりテキストの使用可能領域が減少するため、AutoFit はより早く発動し、フォントが縮小されたりシェイプがリサイズされたりします。AutoFit を調整する前に余白を確認して調整してください。

**AutoFit は手動改行やソフト改行とどのように連動しますか？**

強制改行はそのまま残り、AutoFit はそれらの周囲でフォントサイズと間隔を調整します。不必要な改行を削除すると、AutoFit がテキストを縮小する頻度が低減します。

**テーマフォントの変更やフォント置換は AutoFit の結果に影響しますか？**

はい。字形メトリクスが異なるフォントに置換すると、テキストの幅や高さが変わり、最終的なフォントサイズや改行に影響します。フォントを変更または置換した後は、スライドを再確認してください。