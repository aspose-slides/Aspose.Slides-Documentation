---
title: C++でPowerPointテキスト段落を管理
linktitle: 段落の管理
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
- 段落の箇条書き
- 番号付きリスト
-箇条書きリスト
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
description: "Aspose.Slides for C++ を使用した段落のマスター設定 — PPT、PPTX、ODP プレゼンテーションにおける配置、間隔、スタイルを最適化します。"
---

Aspose.Slides は、C++ で PowerPoint のテキスト、段落、パーツを操作するために必要なすべてのインターフェイスとクラスを提供します。

* Aspose.Slides は、段落を表すオブジェクトを追加できるようにするための [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) インターフェイスを提供します。`ITextFame` オブジェクトは、1 つまたは複数の段落を持つことができ（各段落は改行で作成されます）。
* Aspose.Slides は、パーツを表すオブジェクトを追加できるようにするための [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) インターフェイスを提供します。`IParagraph` オブジェクトは、1 つまたは複数のパーツ（iPortions オブジェクトのコレクション）を持つことができます。
* Aspose.Slides は、テキストとその書式設定プロパティを表すオブジェクトを追加できるようにするための [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) インターフェイスを提供します。

`IParagraph` オブジェクトは、基になる `IPortion` オブジェクトを通じて、さまざまな書式設定プロパティを持つテキストを処理できます。

## **複数のパーツを含む複数の段落を追加**

これらの手順では、3 つの段落を持ち、各段落に 3 つのパーツを含むテキストフレームを追加する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドへの参照にアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
4. [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) に関連付けられた ITextFrame を取得します。
5. 2 つの [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) オブジェクトを作成し、[ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) の `IParagraphs` コレクションに追加します。
6. 各新しい `IParagraph` に対して 3 つの [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) オブジェクトを作成（デフォルトの段落には 2 つの Portion オブジェクト）し、各 `IPortion` オブジェクトを各 `IParagraph` の IPortion コレクションに追加します。
7. 各パーツにテキストを設定します。
8. `IPortion` オブジェクトが提供する書式プロパティを使用して、各パーツに希望する書式設定を適用します。
9. 変更したプレゼンテーションを保存します。

以下の C++ コードは、パーツを含む段落を追加する手順の実装例です。  
```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// 指定したプレゼンテーションをロード
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 矩形タイプのAutoShapeを追加
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// 矩形にTextFrameを追加
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


## **段落の箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。箇条書きされた段落は常に読みやすく、理解しやすくなります。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドへの参照にアクセスします。
3. 選択したスライドに [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. 段落の箇条書き `Type` を `Symbol` に設定し、箇条書き文字を設定します。
8. 段落の `Text` を設定します。
9. 箇条書きの段落 `Indent` を設定します。
10. 箇条書きの色を設定します。
11. 箇条書きの高さを設定します。
12. 新しい段落を `TextFrame` の段落コレクションに追加します。
13. 2 番目の段落を追加し、手順 7 から 13 を繰り返します。
14. プレゼンテーションを保存します。

以下の C++ コードは、段落の箇条書きを追加する方法を示します。  
```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// 目的のプレゼンテーションをロード
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

//テキストを設定
paragraph->set_Text(u"Welcome to Aspose.Slides");

// 箇条書きインデントを設定
paragraph->get_ParagraphFormat()->set_Indent (25);

// 箇条書きの色を設定
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// 独自の箇条書きカラーを使用するためにIsBulletHardColorをtrueに設定
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// 箇条書きの高さを設定
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Paragraphをテキストフレームに追加
txtFrame->get_Paragraphs()->Add(paragraph);

// 2番目のParagraphを作成
// テキストフレーム用のParagraphオブジェクトを作成
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

//テキストを設定
paragraph2->set_Text(u"This is numbered bullet");

// Paragraphの箇条書きタイプとスタイルを設定
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// 箇条書きインデントを設定
paragraph2->get_ParagraphFormat()->set_Indent(25);

// 箇条書きの色を設定
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// 独自の箇条書きカラーを使用するためにIsBulletHardColorをtrueに設定
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// 箇条書きの高さを設定
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Paragraphをテキストフレームに追加
txtFrame->get_Paragraphs()->Add(paragraph2);


// PPTXをディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **画像箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。画像段落は読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドへの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) で画像をロードします。
8. 箇条書きタイプを [Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) に設定し、画像を指定します。
9. 段落の `Text` を設定します。
10. 箇条書きの段落 `Indent` を設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を追加し、前項の手順を繰り返します。
15. 変更したプレゼンテーションを保存します。

以下の C++ コードは、画像箇条書きを追加・管理する方法を示します。  
```c++
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// 最初のスライドにアクセス
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// 箇条書き用の画像を作成
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// AutoShape を追加して取得
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// AutoShape のテキストフレームにアクセス
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

// プレゼンテーションを PPTX ファイルとして保存
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// プレゼンテーションを PPT ファイルとして保存
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```


## **多層箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。多層箇条書きは読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドへの参照にアクセスします。
3. 新しいスライドに [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、深さを 0 に設定します。
7. `Paragraph` クラスを使用して2番目の段落インスタンスを作成し、深さを 1 に設定します。
8. `Paragraph` クラスを使用して3番目の段落インスタンスを作成し、深さを 2 に設定します。
9. `Paragraph` クラスを使用して4番目の段落インスタンスを作成し、深さを 3 に設定します。
10. 新しい段落を `TextFrame` の段落コレクションに追加します。
11. 変更したプレゼンテーションを保存します。

以下の C++ コードは、多層箇条書きを追加・管理する方法を示します。  
```c++
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// 最初のスライドにアクセスします
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// AutoShape を追加して取得します
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// 作成した AutoShape のテキストフレームにアクセスします
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// デフォルトの段落をクリアします
text->get_Paragraphs()->Clear();

// 最初の段落を追加します
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 箇条書きレベルを設定します
para1Format->set_Depth(0);

// 2 番目の段落を追加します
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 箇条書きレベルを設定します
para2Format->set_Depth(1);

// 3 番目の段落を追加します
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 箇条書きレベルを設定します
para3Format->set_Depth(2);

// 4 番目の段落を追加します
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 箇条書きレベルを設定します
para4Format->set_Depth(3);

// 段落をコレクションに追加します
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// プレゼンテーションを PPTX ファイルとして保存します
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```


## **カスタム番号付きリスト付き段落の管理**

[IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) インターフェイスは、[NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) プロパティなどを提供し、カスタム番号付けや書式設定を持つ段落の管理を可能にします。 

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 段落を含むスライドにアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、[NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) を 2 に設定します。
7. `Paragraph` クラスを使用して2番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 3 に設定します。
8. `Paragraph` クラスを使用して3番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 7 に設定します。
9. 新しい段落を `TextFrame` の段落コレクションに追加します。
10. 変更したプレゼンテーションを保存します。

以下の C++ コードは、カスタム番号付きリスト付き段落を追加・管理する方法を示します。  
```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accesses the text frame of created autoshape
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Removes the default existing paragraph
textFrame->get_Paragraphs()->RemoveAt(0);

// First list
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


## **段落インデントの設定**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドへの参照にアクセスします。
3. スライドに矩形の [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
4. 矩形の autoshape に 3 つの段落を持つ [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) を追加します。
5. 矩形の線を非表示にします。
6. 各 [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) の BulletOffset プロパティを使用してインデントを設定します。
7. 変更したプレゼンテーションを PPT ファイルとして書き出します。

以下の C++ コードは、段落インデントを設定する方法を示します。  
```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/AddingSuperscriptAndSubscriptTextInTextFrame_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// 目的のプレゼンテーションをロード
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 矩形タイプの AutoShape を追加
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// 矩形に TextFrame を追加
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


// PPTX をディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **段落のハンギングインデントの設定**

以下の C++ コードは、段落のハンギングインデントを設定する方法を示します。  
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


## **段落の終了ランプロパティの管理**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 位置を指定して段落を含むスライドへの参照を取得します。
3. スライドに矩形の [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
4. 矩形に 2 段落を持つ [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) を追加します。
5. 段落の `FontHeight` とフォント種別を設定します。
6. 段落の End プロパティを設定します。
7. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

以下の C++ コードは、PowerPoint の段落に対して End プロパティを設定する方法を示します。  
```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// 目的のプレゼンテーションをロード
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 矩形タイプの AutoShape を追加
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// 矩形に TextFrame を追加
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// 最初の段落を追加
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// 2 番目の段落を追加
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// PPTX をディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **HTML テキストを段落にインポート**

Aspose.Slides は、HTML テキストを段落にインポートするための高度なサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドへの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
4. `autoshape` の [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) を追加および取得します。
5. `ITextFrame` のデフォルト段落を削除します。
6. TextReader を使ってソース HTML ファイルを読み取ります。
7. [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
8. 読み取った TextReader の HTML コンテンツを TextFrame の [ParagraphCollection](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/) に追加します。
9. 変更したプレゼンテーションを保存します。

以下の C++ コードは、段落に HTML テキストをインポートする手順の実装例です。  
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
	
//デフォルトの塗りつぶしカラーをリセット
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// 矩形に TextFrame を追加
ashp->AddTextFrame(u" ");

// テキストフレームにアクセス
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

//GetParagraphs コレクション
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// 追加されたテキストフレーム内のすべての段落をクリア
ParaCollection->Clear();

// ストリームリーダーで HTML ファイルを読み込む
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// テキストフレームに HTML ストリームリーダーからテキストを追加
ParaCollection->AddFromHtml(tr->ReadToEnd());


// テキストフレーム用の Paragraph オブジェクトを作成
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// 段落用の Portion オブジェクトを作成
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

//部分フォーマットを取得
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Portion のフォントを設定
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// フォントの太字属性を設定
pf->set_FontBold(NullableBool::True);

// フォントの斜体属性を設定
pf->set_FontItalic(NullableBool::True);

// フォントの下線属性を設定
pf->set_FontUnderline(TextUnderlineType::Single);

// フォントの高さを設定
pf->set_FontHeight(25);

// フォントの色を設定
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// PPTX をディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **段落テキストを HTML にエクスポート**

Aspose.Slides は、段落に含まれるテキストを HTML にエクスポートするための高度なサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成し、目的のプレゼンテーションをロードします。
2. インデックスを使用して対象スライドへの参照にアクセスします。
3. HTML にエクスポートするテキストを含むシェイプにアクセスします。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) にアクセスします。
5. `StreamWriter` のインスタンスを作成し、新しい HTML ファイルを追加します。
6. StreamWriter に開始インデックスを指定し、希望する段落をエクスポートします。

以下の C++ コードは、PowerPoint の段落テキストを HTML にエクスポートする方法を示します。  
```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// 指定したプレゼンテーションをロード
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// プレゼンテーションのデフォルトの最初のスライドにアクセス
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 目的のインデックス
int index = 0;

// 追加されたシェイプにアクセス
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// 最初の段落を HTML として抽出
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

//段落の開始インデックスとコピーする総段落数を指定して、段落データを HTML に書き込む
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```


## **段落を画像として保存**

このセクションでは、[IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) インターフェイスで表されるテキスト段落を画像として保存する方法を示す 2 つの例を紹介します。両例とも、[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) インターフェイスの `GetImage` メソッドで段落を含むシェイプの画像を取得し、シェイプ内の段落の境界を計算してビットマップ画像としてエクスポートします。これらの手法により、PowerPoint のプレゼンテーションからテキストの特定部分を抽出し、別個の画像として保存でき、さまざまなシナリオでの活用が可能になります。

sample.pptx という名前のプレゼンテーション ファイルが 1 スライドだけあり、最初のシェイプが 3 段落を含むテキスト ボックスであると仮定します。

![The text box with three paragraphs](paragraph_to_image_input.png)

**Example 1**

この例では、2 番目の段落を画像として取得します。まずプレゼンテーションの最初のスライドからシェイプの画像を抽出し、次にシェイプのテキストフレーム内で 2 番目の段落の境界を計算します。段落は新しいビットマップ画像に再描画され、PNG 形式で保存されます。この方法は、テキストの正確なサイズと書式を保ったまま、特定の段落だけを別画像として保存したい場合に特に有用です。  
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

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


結果:

![The paragraph image](paragraph_to_image_output.png)

**Example 2**

この例では、前例にスケーリング係数を追加して段落画像を拡大します。シェイプはプレゼンテーションから抽出され、スケーリング係数 `2` で画像として保存されます。これにより、段落をエクスポートする際に高解像度の出力が得られます。段落の境界はスケールを考慮して計算されます。スケーリングは、印刷物など高品質な画像が必要な場合に特に有用です。  
```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// スケーリング付きでシェイプをメモリ内のビットマップとして保存。
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

**テキストフレーム内で改行を完全に無効にできますか？**  
はい。テキストフレームのラップメソッド（[set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_wraptext/)）を使用してラップをオフにすれば、フレームの端で行が折り返されません。

**特定の段落のスライド上での正確な境界を取得するにはどうすればよいですか？**  
段落（あるいは単一のパーツ）のバウンディング矩形を取得すれば、スライド上での正確な位置とサイズが分かります。

**段落の配置（左/右/中央/両端揃え）はどこで制御しますか？**  
[Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_alignment/) は [ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/) の段落レベル設定で、個々のパーツの書式設定に関係なく段落全体に適用されます。

**段落の一部（例: 1 単語）のスペルチェック言語を設定できますか？**  
はい。言語はパーツレベルで設定され（[PortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/)）、段落内で複数言語を共存させることが可能です。