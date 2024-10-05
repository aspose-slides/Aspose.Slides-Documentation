---
title: 自動調整設定の管理
type: docs
weight: 30
url: /cpp/manage-autofit-settings/
keywords: "テキストボックス, 自動調整, PowerPoint プレゼンテーション, C++, Aspose.Slides for C++"
description: "C++におけるPowerPointのテキストボックスの自動調整設定を行います"
---

デフォルトでは、テキストボックスを追加すると、Microsoft PowerPointはテキストボックスに対して **テキストに合わせて形状をサイズ変更** 設定を使用します。これにより、テキストボックスは自動的にサイズが調整され、テキストが常に収まります。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* テキストボックスのテキストが長くなると、PowerPointは自動的にテキストボックスを大きくし（高さを増やし）、より多くのテキストを保持できるようにします。
* テキストボックスのテキストが短くなると、PowerPointは自動的にテキストボックスを縮小し（高さを減らし）、余分なスペースを取り除きます。

PowerPointでは、これらはテキストボックスの自動調整動作を制御するための4つの重要なパラメータまたはオプションです：

* **自動調整しない**
* **オーバーフロー時にテキストを縮小**
* **テキストに合わせて形状をサイズ変更**
* **形状内でテキストを折り返す**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for C++は、プレゼンテーション内のテキストボックスの自動調整動作を制御する便利なオプションを提供しています。これには、[TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) クラスのいくつかのメソッドが含まれます。

## **テキストに合わせて形状をサイズ変更**

ボックス内のテキストが常にそのボックスに収まるようにしたい場合は、**テキストに合わせて形状をサイズ変更** オプションを使用する必要があります。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) クラスから）を `Shape` に設定します。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

このC++コードは、PowerPointプレゼンテーションでテキストが常にそのボックスに収まるように指定する方法を示しています：

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

テキストが長くなったり大きくなると、テキストボックスは自動的にサイズが調整（高さが増加）されて、すべてのテキストが収まるようになります。テキストが短くなると、逆の操作が行われます。

## **自動調整しない**

テキストボックスやシェイプが、含まれるテキストの変更に関係なくその寸法を保持するようにしたい場合は、**自動調整しない** オプションを使用する必要があります。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) クラスから）を `None` に設定します。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

このC++コードは、PowerPointプレゼンテーションでテキストボックスが常にその寸法を保持するように指定する方法を示しています：

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

テキストがボックスに対して長すぎる場合、それはあふれ出します。

## **オーバーフロー時にテキストを縮小**

テキストがボックスに対して長すぎる場合、**オーバーフロー時にテキストを縮小** オプションを使用すると、テキストのサイズと間隔を減少させてボックスに収まるように指定できます。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) クラスから）を `Normal` に設定します。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

このC++コードは、PowerPointプレゼンテーションでテキストがオーバーフロー時に縮小されるように指定する方法を示しています：

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

{{% alert title="情報" color="info" %}}

**オーバーフロー時にテキストを縮小** オプションが使用されると、設定はテキストがボックスに対して長すぎるときのみ適用されます。

{{% /alert %}}

## **テキストを折り返す**

シェイプ内のテキストがシェイプの境界（幅のみ）を超えると、テキストがそのシェイプ内で折り返されるようにしたい場合は、**形状内でテキストを折り返す** パラメータを使用する必要があります。この設定を指定するには、[WrapText](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) クラスから）を `true` に設定する必要があります。

このC++コードは、PowerPointプレゼンテーションでテキストを折り返す設定を使用する方法を示しています：

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

{{% alert title="注意" color="warning" %}} 

シェイプの `WrapText` プロパティを `False` に設定すると、シェイプ内部のテキストがシェイプの幅を超えると、テキストが1行でシェイプの境界を越えて伸びます。

{{% /alert %}}