---
title: C++でPowerPointテキスト段落を管理する
linktitle: 段落を管理する
type: docs
weight: 40
url: /ja/cpp/manage-paragraph/
keywords:
- テキストを追加
- 段落を追加
- テキストを管理
- 段落を管理
- 箇条書きを管理
- 段落インデント
- ハンギングインデント
- 段落箇条書き
- 番号付きリスト
- 箇条書きリスト
- 段落プロパティ
- HTMLをインポート
- テキストをHTMLへ
- 段落をHTMLへ
- 段落を画像へ
- テキストを画像へ
- 段落をエクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++で段落書式設定をマスターし、C++のPPT、PPTX、ODPプレゼンテーションで配置、間隔、スタイルを最適化します。"
---
Aspose.Slides は、C++ で PowerPoint のテキスト、段落、ポーションを操作するために必要なすべてのインターフェイスとクラスを提供します。

* Aspose.Slides は、段落を表すオブジェクトを追加できるようにする [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) インターフェイスを提供します。`ITextFame` オブジェクトは 1 つまたは複数の段落を持つことができ（各段落は改行で作成されます）。
* Aspose.Slides は、ポーションを表すオブジェクトを追加できるようにする [IParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/) インターフェイスを提供します。`IParagraph` オブジェクトは 1 つまたは複数のポーション（iPortions オブジェクトのコレクション）を持つことができます。
* Aspose.Slides は、テキストとその書式設定プロパティを表すオブジェクトを追加できるようにする [IPortion](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/) インターフェイスを提供します。

`IParagraph` オブジェクトは、その基礎となる `IPortion` オブジェクトを介して、異なる書式設定プロパティを持つテキストを処理することができます。

## **複数のポーションを含む複数の段落を追加する**

以下の手順では、3 つの段落を含み、各段落が 3 つのポーションを含むテキストフレームを追加する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
4. [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) に関連付けられた ITextFrame を取得します。
5. 2 つの [IParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/) オブジェクトを作成し、[ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) の `IParagraphs` コレクションに追加します。
6. 各新しい `IParagraph` に対して 3 つの [IPortion](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/) オブジェクト（デフォルトの段落には 2 つの Portion オブジェクト）を作成し、各 `IPortion` オブジェクトをそれぞれの `IParagraph` の IPortion コレクションに追加します。
7. 各ポーションにテキストを設定します。
8. `IPortion` オブジェクトが提供する書式設定プロパティを使用して、各ポーションに好みの書式設定機能を適用します。
9. 変更したプレゼンテーションを保存します。

```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Load the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Access first slide
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Add an AutoShape of Rectangle type
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Add TextFrame to the Rectangle
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Accessing the first Paragraph
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Adding second Paragraph
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Adding third Paragraph
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

// Save PPTX to Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **段落の箇条書きを管理する**

箇条書きリストは、情報を迅速かつ効果的に整理・提示するのに役立ちます。箇条書きされた段落は、常に読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 選択したスライドに [autoshape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. 段落の箇条書き `Type` を `Symbol` に設定し、箇条書き文字を設定します。
8. 段落の `Text` を設定します。
9. 箇条書きの段落 `Indent` を設定します。
10. 箇条書きの色を設定します。
11. 箇条書きの高さを設定します。
12. 新しい段落を `TextFrame` の段落コレクションに追加します。
13. 2 番目の段落を追加し、手順 7 から 12 のプロセスを繰り返します。
14. プレゼンテーションを保存します。

```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// 必要なプレゼンテーションをロード
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 矩形タイプのAutoShapeを追加
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// 矩形にTextFrameを追加
ashp->AddTextFrame(u"");

// テキストフレームにアクセス
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// テキストフレーム用のParagraphオブジェクトを作成
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// テキストを設定
paragraph->set_Text(u"Welcome to Aspose.Slides");

// 箇条書きのインデントを設定
paragraph->get_ParagraphFormat()->set_Indent (25);

// 箇条書きの色を設定
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// 独自の箇条書き色を使用するために IsBulletHardColor を true に設定
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// 箇条書きの高さを設定
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Paragraph をテキストフレームに追加
txtFrame->get_Paragraphs()->Add(paragraph);

// 2つ目の段落を作成
// テキストフレーム用のParagraphオブジェクトを作成
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

// テキストを設定
paragraph2->set_Text(u"This is numbered bullet");

// 段落の箇条書きタイプとスタイルを設定
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// 箇条書きのインデントを設定
paragraph2->get_ParagraphFormat()->set_Indent(25);

// 箇条書きの色を設定
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// 独自の箇条書き色を使用するために IsBulletHardColor を true に設定
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// 箇条書きの高さを設定
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Paragraph をテキストフレームに追加
txtFrame->get_Paragraphs()->Add(paragraph2);


// PPTX をディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **画像箇条書きを管理する**

箇条書きリストは、情報を迅速かつ効果的に整理・提示するのに役立ちます。画像段落は読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) で画像をロードします。
8. 箇条書きのタイプを [Picture](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) に設定し、画像を指定します。
9. 段落の `Text` を設定します。
10. 箇条書きの段落 `Indent` を設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を追加し、前の手順に基づいてプロセスを繰り返します。
15. 変更したプレゼンテーションを保存します。

```c++
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// 最初のスライドにアクセス
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// 箇条書き用の画像を作成
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// AutoShape を追加してアクセス
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// AutoShape の TextFrame にアクセス
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

// 段落を TextFrame に追加
paragraphs->Add(paragraph);

// プレゼンテーションを PPTX ファイルとして保存
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// プレゼンテーションを PPT ファイルとして保存
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **階層付き箇条書きを管理する**

箇条書きリストは、情報を迅速かつ効果的に整理・提示するのに役立ちます。階層付き箇条書きは読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 新しいスライドに [autoshape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/paragraph/) クラスを通じて最初の段落インスタンスを作成し、深さを 0 に設定します。
7. `Paragraph` クラスを使用して 2 番目の段落インスタンスを作成し、深さを 1 に設定します。
8. `Paragraph` クラスを使用して 3 番目の段落インスタンスを作成し、深さを 2 に設定します。
9. `Paragraph` クラスを使用して 4 番目の段落インスタンスを作成し、深さを 3 に設定します。
10. 新しい段落を `TextFrame` の段落コレクションに追加します。
11. 変更したプレゼンテーションを保存します。

```c++
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// 最初のスライドにアクセス
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// AutoShape を追加してアクセス
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// 作成した AutoShape のテキストフレームにアクセス
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

// 2 番目の段落を追加
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

// 3 番目の段落を追加
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

// 4 番目の段落を追加
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

// プレゼンテーションを PPTX ファイルとして保存
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **カスタム番号リスト付き段落を管理する**

[IBulletFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/) インターフェイスは、[NumberedBulletStartWith](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) プロパティなどを提供し、カスタム番号付けや書式設定された段落を管理できるようにします。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 該当段落が含まれるスライドにアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/paragraph/) クラスを通じて最初の段落インスタンスを作成し、[NumberedBulletStartWith](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) を 2 に設定します。
7. `Paragraph` クラスを使用して 2 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 3 に設定します。
8. `Paragraph` クラスを使用して 3 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 7 に設定します。
9. 新しい段落を `TextFrame` の段落コレクションに追加します。
10. 変更したプレゼンテーションを保存します。

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// 作成した autoshape のテキストフレームにアクセス
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// 既存のデフォルト段落を削除
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

## **段落の先頭行インデントを設定する**

[IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_indent/) メソッドを使用して、段落の先頭行インデントを制御します。このメソッドは段落の左余白に対して最初の行だけを移動させます。正の値は先頭行を右方向にシフトし、残りの行は段落本文に揃ったままです。

段落全体を移動させたい場合は [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_marginleft/) を使用します。最初の行だけを移動させたい場合は [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_indent/) を使用します。

以下の例では、複数の段落を作成し、異なる `Indent` 値を適用して、先頭行インデントが段落レイアウトに与える影響を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/autoshape/) を追加します。
4. シェイプに空の [TextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/textframe/) を追加し、デフォルトの段落を削除します。
5. 複数の段落を作成し、それぞれに異なる [Indent](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_indent/) 値を設定します。
6. 段落をテキストフレームに追加します。
7. 変更したプレゼンテーションを保存します。

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
firstParagraph->get_ParagraphFormat()->set_Indent(0.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
secondParagraph->get_ParagraphFormat()->set_Indent(20.f);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
thirdParagraph->get_ParagraphFormat()->set_Indent(40.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果:
![The first-line indent of the paragraphs](first_line_indent.png)

## **段落のハンギングインデントを設定する**

ハンギングインデントは、最初の行が残りの行より左側から始まる段落レイアウトです。Aspose.Slides では、[IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_indent/) メソッドを使用してこの効果を作成します。インデントを負の値に設定すると、段落本文に対して最初の行が左に移動します。

実際には、[IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_marginleft/) が段落本文の左位置を定義し、[IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_indent/) がその余白に対する最初の行の位置を定義します。ハンギングインデントを作成するには、正の `MarginLeft` 値と負の `Indent` 値を設定します。

この書式設定は、文献リスト、参考文献、用語集の項目など、折り返し行が最初の文字ではなく段落本文の下に揃える必要がある段落に便利です。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/autoshape/) を追加します。
4. シェイプに空の [TextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/textframe/) を追加し、デフォルトの段落を削除します。
5. 各段落に対して正の [MarginLeft](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_marginleft/) 値を設定し、段落を作成します。
6. ハンギングインデント効果を作成するために、負の [Indent](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_indent/) 値を設定します。
7. 段落をテキストフレームに追加します。
8. 変更したプレゼンテーションを保存します。

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40.f);
firstParagraph->get_ParagraphFormat()->set_Indent(-20.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60.f);
secondParagraph->get_ParagraphFormat()->set_Indent(-30.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果:
![The hanging indent of the paragraphs](hanging_indent.png)

## **段落の End Run プロパティを管理する**

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 位置を使用して、段落が含まれるスライドの参照を取得します。
3. スライドに矩形の [autoshape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
4. 矩形に 2 つの段落を持つ [TextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) を追加します。
5. 段落の `FontHeight` とフォントタイプを設定します。
6. 段落の End プロパティを設定します。
7. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Load the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Access first slide
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Add an AutoShape of Rectangle type
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Add TextFrame to the Rectangle
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Adding the first Paragraph
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// Adding the second Paragraph
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// Save PPTX to Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **HTML テキストを段落にインポートする**

Aspose.Slides は、HTML テキストを段落にインポートするための強化されたサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
4. `autoshape` の [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) を追加し、アクセスします。
5. `ITextFrame` のデフォルト段落を削除します。
6. TextReader でソース HTML ファイルを読み取ります。
7. [Paragraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
8. 読み取った TextReader の HTML ファイル内容を TextFrame の [ParagraphCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/paragraphcollection/) に追加します。
9. 変更したプレゼンテーションを保存します。

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// 目的のプレゼンテーションをロード
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 矩形タイプの AutoShape を追加
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
//デフォルトの塗りつぶし色をリセット
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// 矩形に TextFrame を追加
ashp->AddTextFrame(u" ");

// テキストフレームにアクセス
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

//GetParagraphs コレクションを取得
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Clearing all paragraphs in added text frame
ParaCollection->Clear();

// Loading the HTML file using stream reader
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Adding text from HTML stream reader in text frame
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Create the Paragraph object for text frame
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Create Portion object for paragraph
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

//Get portion format
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Set the Font for the Portion
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Set Bold property of the Font
pf->set_FontBold(NullableBool::True);

// Set Italic property of the Font
pf->set_FontItalic(NullableBool::True);

// Set Underline property of the Font
pf->set_FontUnderline(TextUnderlineType::Single);

// Set the Height of the Font
pf->set_FontHeight(25);

// Set the color of the Font
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Save PPTX to Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **段落テキストを HTML にエクスポートする**

Aspose.Slides は、段落に含まれるテキストを HTML にエクスポートするための強化されたサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成し、目的のプレゼンテーションをロードします。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. HTML にエクスポートするテキストを含むシェイプにアクセスします。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) にアクセスします。
5. `StreamWriter` のインスタンスを作成し、新しい HTML ファイルを追加します。
6. StreamWriter に開始インデックスを指定し、希望する段落をエクスポートします。

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Load the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// プレゼンテーションのデフォルトの最初のスライドにアクセス
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Desired index
int index = 0;

// 追加されたシェイプにアクセス
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Extracting first paragraph as HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Paragraph データを書き込んで HTML を生成（開始インデックスとコピーする段落数を指定）
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```

## **段落を画像として保存する**

このセクションでは、[IParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/) インターフェイスで表されるテキスト段落を画像として保存する方法を示す 2 つの例を紹介します。両例とも、[IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/) インターフェイスの `GetImage` メソッドを使用して段落を含むシェイプの画像を取得し、シェイプ内の段落の境界を計算してビットマップ画像としてエクスポートします。このアプローチにより、PowerPoint プレゼンテーションからテキストの特定部分を抽出し、別々の画像として保存でき、さまざまなシナリオでの利用に役立ちます。

sample.pptx というプレゼンテーション ファイルがあり、1 枚のスライドがあり、最初のシェイプが 3 つの段落を含むテキストボックスであると仮定します。

![The text box with three paragraphs](paragraph_to_image_input.png)

**例 1**

この例では、2 番目の段落を画像として取得します。そのために、プレゼンテーションの最初のスライドからシェイプの画像を抽出し、シェイプのテキストフレーム内の 2 番目の段落の境界を計算します。次に、段落を新しいビットマップ画像に再描画し、PNG 形式で保存します。この方法は、テキストの正確なサイズと書式を保持したまま、特定の段落を別々の画像として保存する必要がある場合に特に有用です。

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// メモリ内にシェイプをビットマップとして保存する。
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// メモリからシェイプのビットマップを作成する。
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// 2番目の段落の境界を計算する。
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// 出力画像のサイズを計算する（最小サイズ - 1x1 ピクセル）。
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// 段落用のビットマップを準備する。
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// シェイプのビットマップから段落のビットマップへ段落を再描画する。
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

結果:
![The paragraph image](paragraph_to_image_output.png)

**例 2**

この例では、段落画像にスケーリング係数を追加して前述のアプローチを拡張します。シェイプはプレゼンテーションから抽出され、スケーリング係数 `2` で画像として保存されます。これにより、段落をエクスポートする際に高解像度の出力が可能になります。その後、スケールを考慮して段落の境界を計算します。スケーリングは、より詳細な画像が必要な場合、たとえば高品質の印刷物での使用に特に有用です。

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap with scaling.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

## **FAQ**

**テキストフレーム内の改行を完全に無効にできますか？**

はい。テキストフレームのラップ方法（[set_WrapText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/textframeformat/set_wraptext/)）を使用してラップをオフにすれば、行がフレームの端で折り返されなくなります。

**特定の段落のスライド上での正確な境界を取得するにはどうすればよいですか？**

段落（さらには単一のポーション）のバウンディング矩形を取得することで、スライド上での正確な位置とサイズを把握できます。

**段落の配置（左揃え/右揃え/中央揃え/均等揃え）はどこで制御されますか？**

[Alignment](https://reference.aspose.com/slides/ja/cpp/aspose.slides/paragraphformat/set_alignment/) は [ParagraphFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/paragraphformat/) の段落レベル設定であり、個々のポーションの書式設定に関係なく段落全体に適用されます。

**段落の一部（例：単語）だけにスペルチェック言語を設定できますか？**

はい。言語はポーションレベルで（[PortionFormat::set_LanguageId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/baseportionformat/set_languageid/)）設定されるため、1 つの段落内で複数の言語が共存できます。