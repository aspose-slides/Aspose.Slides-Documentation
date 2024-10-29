---
title: プレゼンテーションプロパティ
type: docs
weight: 70
url: /ja/cpp/presentation-properties/
---


## **プレゼンテーションプロパティへのアクセス**
前述のように、Aspose.Slides for C++は、**組み込み**および**カスタム**プロパティの2種類のドキュメントプロパティをサポートしています。したがって、開発者はAspose.Slides for C++ APIを使用して、両方の種類のプロパティにアクセスできます。Aspose.Slides for C++は、[IDocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_document_properties)クラスを提供しており、[Presentation::get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402)メソッドを介してプレゼンテーションファイルに関連付けられたドキュメントプロパティを表します。開発者は、次に説明するように、**Presentation**オブジェクトによって公開された[get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402)メソッドを使用して、プレゼンテーションファイルのドキュメントプロパティにアクセスできます。

{{% alert color="primary" %}} 

**Application**および**Producer**フィールドに対して値を設定できないことに注意してください。これらのフィールドには、Aspose Ltd.とAspose.Slides for C++ x.x.xが表示されます。

{{% /alert %}} 


Microsoft PowerPointは、プレゼンテーションファイルにいくつかのプロパティを追加する機能を提供しています。これらのドキュメントプロパティは、ドキュメント（プレゼンテーションファイル）とともに便利な情報を保存することを可能にします。ドキュメントプロパティには以下の2種類があります。

- システム定義（組み込み）プロパティ
- ユーザー定義（カスタム）プロパティ

**組み込み**プロパティには、ドキュメントのタイトル、著者の名前、ドキュメント統計など、ドキュメントに関する一般的な情報が含まれます。**カスタム**プロパティは、ユーザーによって**名前/値**ペアとして定義されるプロパティであり、名前と値はどちらもユーザーによって定義されます。Aspose.Slides for C++を使用すると、開発者は組み込みプロパティとカスタムプロパティの値をアクセスおよび変更できます。Microsoft PowerPoint 2007では、プレゼンテーションファイルのドキュメントプロパティを管理できます。やるべきことは、Officeアイコンをクリックし、さらに**準備 | プロパティ | 詳細プロパティ**メニュー項目に進むことだけです。**詳細プロパティ**メニュー項目を選択すると、PowerPointファイルのドキュメントプロパティを管理するためのダイアログが表示されます。**プロパティダイアログ**では、**一般、要約、統計、内容、およびカスタム**などの多くのタブページがあることがわかります。これらのすべてのタブページは、PowerPointファイルに関連するさまざまな情報を構成することを可能にします。**カスタム**タブは、PowerPointファイルのカスタムプロパティを管理するために使用されます。


## **組み込みプロパティへのアクセス**
**IDocumentProperties**オブジェクトによって公開されたこれらのプロパティには、**Creator(Author)**、**Description**、**KeyWords**、**Created**（作成日）、**Modified**（変更日）、**Printed**（最終印刷日）、**LastModifiedBy**、**Keywords**、**SharedDoc**（異なるプロデューサー間で共有されていますか？）、**PresentationFormat**、**Subject**、**Title**が含まれます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}
## **組み込みプロパティの変更**
プレゼンテーションファイルの組み込みプロパティを変更することは、それにアクセスするのと同じくらい簡単です。任意の必要なプロパティに文字列値を割り当てるだけで、プロパティの値が変更されます。以下の例では、プレゼンテーションファイルの組み込みドキュメントプロパティをどのように変更できるかを示しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **カスタムプレゼンテーションプロパティの追加**
Aspose.Slides for C++は、開発者がプレゼンテーションドキュメントプロパティにカスタム値を追加することも許可しています。以下に、プレゼンテーションのカスタムプロパティを設定する方法を示す例があります。

``` cpp
// Presentationクラスをインスタンス化
auto presentation = System::MakeObject<Presentation>();

// ドキュメントプロパティの取得
auto documentProperties = presentation->get_DocumentProperties();

// カスタムプロパティの追加
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// 特定のインデックスでプロパティ名を取得
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// 選択したプロパティの削除
documentProperties->RemoveCustomProperty(getPropertyName);

// プレゼンテーションの保存
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **カスタムプレゼンテーションプロパティへのアクセスと変更**
Aspose.Slides for C++は、開発者がカスタムプロパティの値にアクセスすることも許可しています。以下に、プレゼンテーションのこれらのカスタムプロパティにアクセスして変更する方法を示す例があります。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}


## **プレゼンテーションが変更されたか作成されたかの確認**
Aspose.Slides for C++は、プレゼンテーションが変更されたか作成されたかを確認する機能を提供しています。以下に、プレゼンテーションが作成されたか変更されたかを確認する方法を示す例があります。

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"props.pptx");

auto props = info->ReadDocumentProperties();

String app = props->get_NameOfApplication();
String ver = props->get_AppVersion();
```

## **校正言語の設定**

Aspose.Slidesは、[LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/)プロパティ（[PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/)クラスによって公開）を提供し、PowerPointドキュメントの校正言語を設定できるようにします。校正言語は、PowerPoint内のスペルと文法がチェックされる言語です。

このC++コードは、PowerPointの校正言語を設定する方法を示しています。

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// 校正言語のIDを設定

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **デフォルト言語の設定**

このC++コードは、PowerPointプレゼンテーション全体のデフォルト言語を設定する方法を示しています。

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// テキストを持つ新しい長方形形状を追加
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"新しいテキスト");

// 最初のポーションの言語を確認
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```