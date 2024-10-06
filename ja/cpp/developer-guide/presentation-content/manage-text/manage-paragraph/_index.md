---
title: C++でPowerPointの段落を管理する
type: docs
weight: 40
url: /ja/cpp/manage-paragraph/
keywords: "PowerPoint段落の追加, 段落の管理, 段落のインデント, 段落のプロパティ, HTMLテキスト, 段落テキストのエクスポート, PowerPointプレゼンテーション, C++, CPP, Aspose.Slides for C++"
description: "C++でPowerPointプレゼンテーションの段落、テキスト、インデント、およびプロパティを作成および管理する"
---

Aspose.Slidesは、C++でPowerPointのテキスト、段落、部分を操作するために必要なすべてのインターフェイスとクラスを提供します。

* Aspose.Slidesは、段落を表すオブジェクトを追加するために[ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)インターフェイスを提供します。`ITextFrame`オブジェクトは、1つまたは複数の段落を持つことができます（各段落は改行によって作成されます）。
* Aspose.Slidesは、部分を表すオブジェクトを追加するために[IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/)インターフェイスを提供します。`IParagraph`オブジェクトは、1つまたは複数の部分（iPortionsオブジェクトの集合）を持つことができます。
* Aspose.Slidesは、テキストとその書式設定プロパティを表すオブジェクトを追加するための[IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/)インターフェイスを提供します。

`IParagraph`オブジェクトは、基盤となる`IPortion`オブジェクトを通じて、異なる書式設定プロパティを持つテキストを処理できます。

## **複数の部分を含む複数の段落を追加する**

以下の手順は、3つの段落を含むテキストフレームと、各段落が3つの部分を含む方法を示します：

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. スライドに長方形の[IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)を追加します。
4. [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)に関連付けられたITextFrameを取得します。
5. 2つの[IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/)オブジェクトを作成し、それらを[ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)の`IParagraphs`コレクションに追加します。
6. 各新しい`IParagraph`のために3つの[IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/)オブジェクトを作成し、各`IPortion`オブジェクトをそれぞれの`IParagraph`のIPortionコレクションに追加します。
7. 各部分のテキストを設定します。
8. `IPortion`オブジェクトが公開する書式設定プロパティを使用して、各部分に好きな書式設定機能を適用します。
9. 修正されたプレゼンテーションを保存します。

このC++コードは、部分を含む段落を追加する手順の実装です：

```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// プレゼンテーションをロードする
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 長方形のAutoShapeを追加
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// 長方形にTextFrameを追加
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// 最初の段落にアクセス
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// 2番目の段落を追加
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// 3番目の段落を追加
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para2);
SharedPtr<Portion> port20 = MakeObject<Portion>();
SharedPtr<Portion> port21 = MakeObject<Portion>();
SharedPtr<Portion> port22 = MakeObject<Portion>();
para2->get_Portions()->Add(port20);
para2->get_Portions()->Add(port21);
para2->get_Portions()->Add(port22);


for (int i = 0; i < 3; i++)
{
	for (int j = 0; j < 3; j++)
	{
		tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->set_Text(u"Portion_"+j);
		SharedPtr<IPortionFormat>format = tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->get_PortionFormat();

		if (j == 0)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(15);
		}
		else if (j == 1)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(18);
		}
	}

}

// PPTXをディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **段落の箇条書きを管理する**

箇条書きリストは、情報を迅速かつ効率的に整理して提示するのに役立ちます。箇条書きの段落は、常に読みやすく、理解しやすいものです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. 選択したスライドに[autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)にアクセスします。
5. `TextFrame`のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成します。
7. 段落の箇条書き`Type`を`Symbol`に設定し、箇条書き文字を設定します。
8. 段落の`Text`を設定します。
9. 箇条書きの段落の`Indent`を設定します。
10. 箇条書きに色を設定します。
11. 箇条書きの高さを設定します。
12. 新しい段落を`TextFrame`の段落コレクションに追加します。
13. 2番目の段落を追加し、7から13の手順を繰り返します。
14. プレゼンテーションを保存します。

このC++コードは、段落の箇条書きを追加する方法を示しています：

```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// プレゼンテーションをロードする
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 長方形のAutoShapeを追加
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// 長方形にTextFrameを追加
ashp->AddTextFrame(u"");

// テキストフレームにアクセス
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// テキストフレーム用の段落オブジェクトを作成
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// テキストを設定
paragraph->set_Text(u"Welcome to Aspose.Slides");

// 箇条書きのインデントを設定
paragraph->get_ParagraphFormat()->set_Indent(25);

// 箇条書きの色を設定
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// 自分の箇条書き色を使うためにIsBulletHardColorをtrueに設定
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// 箇条書きの高さを設定
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// 段落をテキストフレームに追加
txtFrame->get_Paragraphs()->Add(paragraph);

// 2番目の段落を作成
// テキストフレーム用の段落オブジェクトを作成
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

// テキストを設定
paragraph2->set_Text(u"This is numbered bullet");

// 段落の箇条書きタイプとスタイルを設定
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// 箇条書きのインデントを設定
paragraph2->get_ParagraphFormat()->set_Indent(25);

// 箇条書きの色を設定
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// 自分の箇条書き色を使うためにIsBulletHardColorをtrueに設定
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// 箇条書きの高さを設定
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// 段落をテキストフレームに追加
txtFrame->get_Paragraphs()->Add(paragraph2);


// PPTXをディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **画像の箇条書きを管理する**

箇条書きリストは、情報を迅速かつ効率的に整理して提示するのに役立ちます。画像段落は、読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. スライドに[autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)にアクセスします。
5. `TextFrame`のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成します。
7. [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)に画像をロードします。
8. 箇条書きのタイプを[Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)に設定し、画像を設定します。
9. 段落の`Text`を設定します。
10. 段落の`Indent`を箇条書きのために設定します。
11. 箇条書きに色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を`TextFrame`の段落コレクションに追加します。
14. 2番目の段落を追加し、前の手順に基づいてプロセスを繰り返します。
15. 修正されたプレゼンテーションを保存します。

このC++コードは、画像の箇条書きを追加および管理する方法を示しています：

```c++
// PPTXファイルを表すPresentationクラスをインスタンス化します
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// 最初のスライドにアクセス
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// 箇条書き用の画像をインスタンス化
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Autoshapeを追加してアクセス
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// autoshapeのテキストフレームにアクセス
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// デフォルトの段落を削除
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// 新しい段落を作成
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// 段落の箇条書きスタイルと画像を設定
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// 箇条書きの高さを設定
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// 段落をテキストフレームに追加
paragraphs->Add(paragraph);

// プレゼンテーションをPPTXファイルとして保存
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// プレゼンテーションをPPTファイルとして保存
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```


## **階層箇条書きを管理する**

箇条書きリストは、情報を迅速かつ効率的に整理して提示するのに役立ちます。階層箇条書きは、読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. 新しいスライドに[autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)にアクセスします。 
5. `TextFrame`のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成し、深さを0に設定します。
7. [Paragraph]クラスを通じて2番目の段落インスタンスを作成し、深さを1に設定します。
8. [Paragraph]クラスを通じて3番目の段落インスタンスを作成し、深さを2に設定します。
9. [Paragraph]クラスを通じて4番目の段落インスタンスを作成し、深さを3に設定します。
10. 新しい段落を`TextFrame`の段落コレクションに追加します。
11. 修正されたプレゼンテーションを保存します。

このC++コードは、階層箇条書きを追加および管理する方法を示しています：

```c++
// PPTXファイルを表すPresentationクラスをインスタンス化します
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// 最初のスライドにアクセス
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Autoshapeを追加してアクセス
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// 作成したautoshapeのテキストフレームにアクセス
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// デフォルトの段落をクリア
text->get_Paragraphs()->Clear();

// 最初の段落を追加
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 箇条書きレベルを設定
para1Format->set_Depth(0);

// 2番目の段落を追加
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 箇条書きレベルを設定
para2Format->set_Depth(1);

// 3番目の段落を追加
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 箇条書きレベルを設定
para3Format->set_Depth(2);

// 4番目の段落を追加
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 箇条書きレベルを設定
para4Format->set_Depth(3);

// 段落をコレクションに追加
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// プレゼンテーションをPPTXファイルとして書き出す
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```


## **カスタム番号付きリストの段落を管理する**

[IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/)インターフェイスは、カスタム番号付けまたは書式設定を管理するために[NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/)プロパティなどを提供します。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. 段落を含むスライドにアクセスします。
3. スライドに[autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)にアクセスします。 
5. `TextFrame`のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成し、[NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/)を2に設定します。
7. [Paragraph]クラスを使用して2番目の段落インスタンスを作成し、`NumberedBulletStartWith`を3に設定します。
8. [Paragraph]クラスを使用して3番目の段落インスタンスを作成し、`NumberedBulletStartWith`を7に設定します。
9. 新しい段落を`TextFrame`の段落コレクションに追加します。
10. 修正されたプレゼンテーションを保存します。

このC++コードは、カスタム番号付けまたは書式設定を持つ段落を追加および管理する方法を示しています：

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// 作成したautoshapeのテキストフレームにアクセス
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// 既存のデフォルトの段落を削除
textFrame->get_Paragraphs()->RemoveAt(0);

// 最初のリスト
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"bullet 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"bullet 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"bullet 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```


## **段落インデントを設定する**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. スライドに長方形の[autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)を追加します。
4. 長方形のautoshapeに3つの段落を持つ[TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)を追加します。
5. 長方形の線を非表示にします。
6. 各[Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/)のBulletOffsetプロパティを介してインデントを設定します。
7. 修正されたプレゼンテーションをPPTファイルとして書き出します。

このC++コードは、段落のインデントを設定する方法を示しています：

```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/AddingSuperscriptAndSubscriptTextInTextFrame_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// プレゼンテーションをロードする
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 長方形のAutoShapeを追加
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// 長方形にTextFrameを追加
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

tf->get_Paragraphs()->Clear();

// 最初の段落を追加
SharedPtr<Paragraph> superPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion1 = MakeObject<Portion>(u"SlideTitle");
superPar->get_Portions()->Add(portion1);

SharedPtr<Portion> superPortion = MakeObject<Portion>();
superPortion->get_PortionFormat()->set_Escapement(30);
superPortion->set_Text(u"TM");
superPar->get_Portions()->Add(superPortion);


// 最初の段落を追加
SharedPtr<Paragraph> subPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion2 = MakeObject<Portion>(u"a");
subPar->get_Portions()->Add(portion2);

SharedPtr<Portion> subPortion = MakeObject<Portion>();
subPortion->get_PortionFormat()->set_Escapement(-25);
subPortion->set_Text(u"i");
subPar->get_Portions()->Add(subPortion);

// テキストフレームに追加
ashp->get_TextFrame()->get_Paragraphs()->Add(superPar);
ashp->get_TextFrame()->get_Paragraphs()->Add(subPar);


// PPTXをディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **段落のハンギングインデントを設定する**

このC++コードは、段落のハンギングインデントを設定する方法を示しています：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 250.0f, 550.0f, 150.0f);

System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Example");
System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Set Hanging Indent for Paragraph");
System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"This C# code shows you how to set the hanging indent for a paragraph: ");

para2->get_ParagraphFormat()->set_MarginLeft(10.f);
para3->get_ParagraphFormat()->set_MarginLeft(20.f);

auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **段落の終了段落ランプロパティを管理する**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. 位置を介して段落を含むスライドへの参照を取得します。
3. スライドに長方形の[autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)を追加します。
4. 長方形に2つの段落を持つ[TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)を追加します。
5. 段落のフォントサイズとフォントタイプを設定します。
6. 段落の終了プロパティを設定します。
7. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このC++コードは、PowerPointの段落の終了プロパティを設定する方法を示しています：

```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// プレゼンテーションをロードする
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 長方形のAutoShapeを追加
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// 長方形にTextFrameを追加
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// 最初の段落を追加
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// 2番目の段落を追加
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// PPTXをディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **HTMLテキストを段落にインポートする**

Aspose.Slidesは、HTMLテキストを段落にインポートするための強化されたサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. スライドに[autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)を追加してアクセスします。
5. `ITextFrame`のデフォルトの段落を削除します。
6. TextReaderでソースHTMLファイルを読み取ります。
7. [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成します。
8. 読み取ったTextReaderのHTMLファイル内容をTextFrameの[ParagraphCollection](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/)に追加します。
9. 修正されたプレゼンテーションを保存します。

このC++コードは、段落にHTMLテキストをインポートする手順の実装です： 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// プレゼンテーションをロードする
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 長方形のAutoShapeを追加
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// デフォルトの塗りつぶし色をリセット
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// 長方形にTextFrameを追加
ashp->AddTextFrame(u" ");

// テキストフレームにアクセス
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

//Paragraphsコレクションを取得
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// 追加されたテキストフレーム内のすべての段落をクリア
ParaCollection->Clear();

// ストリームリーダーを使用してHTMLファイルを読み込む
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// テキストフレームにHTMLストリームリーダーからのテキストを追加
ParaCollection->AddFromHtml(tr->ReadToEnd());


// テキストフレーム用の段落オブジェクトを作成
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// 段落用のPortionオブジェクトを作成
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

//ポーションフォーマットを取得
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// ポーションのフォントを設定
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// フォントの太字プロパティを設定
pf->set_FontBold(NullableBool::True);

// フォントのイタリックプロパティを設定
pf->set_FontItalic(NullableBool::True);

// フォントの下線プロパティを設定
pf->set_FontUnderline(TextUnderlineType::Single);

// フォントの高さを設定
pf->set_FontHeight(25);

// フォントの色を設定
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// PPTXをディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```


## **段落のテキストをHTMLにエクスポートする**

Aspose.Slidesは、段落に含まれるテキストをHTMLにエクスポートするための強化されたサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成し、希望するプレゼンテーションをロードします。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. HTMLにエクスポートされるテキストを含むシェイプにアクセスします。
4. シェイプの[TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)にアクセスします。
5. `StreamWriter`のインスタンスを作成し、新しいHTMLファイルを追加します。
6. StreamWriterに開始インデックスを指定し、希望の段落をエクスポートします。

このC++コードは、PowerPointの段落テキストをHTMLにエクスポートする方法を示しています：

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// プレゼンテーションをロードする
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// プレゼンテーションのデフォルトの最初のスライドにアクセス
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 希望のインデックス
int index = 0;

// 追加されたシェイプにアクセス
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// 最初の段落をHTMLとして抽出
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// 段落データをHTMLに書き出す
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```