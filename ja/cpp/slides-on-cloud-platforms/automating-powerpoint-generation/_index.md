---
title: "C++ で PowerPoint の自動生成: 動的なプレゼンテーションを簡単に作成"
linktitle: PowerPoint 自動生成
type: docs
weight: 20
url: /ja/cpp/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- クラウド プラットフォーム
- PowerPoint の自動生成
- プログラムでプレゼンテーションを生成
- PowerPoint 自動化
- 動的スライド作成
- 自動化されたビジネスレポート
- PPT 自動化
- C++ プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してクラウド プラットフォーム上でスライド作成を自動化し、PowerPoint と OpenDocument ファイルを高速かつ信頼性を持って生成、編集、変換します。"
---

## **はじめに**

PowerPoint プレゼンテーションを手動で作成することは、時間がかかり繰り返しの作業になることがあります—特にコンテンツが頻繁に変わる動的データに基づく場合はなおさらです。週次の業務レポート作成、教育教材の組み立て、クライアント向けの営業デッキ作成など、Automation によって膨大な時間を節約し、チーム全体での一貫性を確保できます。

C++ 開発者にとって、PowerPoint プレゼンテーションの作成を自動化することは強力な可能性を開きます。スライド生成を Web ポータル、デスクトップツール、バックエンドサービス、またはクラウドプラットフォームに統合し、データをプロフェッショナルでブランド化されたプレゼンテーションへオンデマンドで変換できます。

本記事では、C++ アプリ（クラウド プラットフォームへのデプロイを含む）における自動 PowerPoint 生成の代表的なユースケースと、現代ソリューションで必須機能となりつつある理由を探ります。リアルタイムの業務データ取得からテキストや画像をスライドに変換するまで、目的は生データを構造化された視覚フォーマットへ変換し、受け手が即座に理解できるようにすることです。

## **C++ における PowerPoint 自動化の一般的なユースケース**

PowerPoint の生成を自動化することは、プレゼンテーション コンテンツを動的に組み立てたり、パーソナライズしたり、頻繁に更新したりする必要があるシナリオで特に有用です。最も一般的な実世界のユースケースには次のようなものがあります：

- **ビジネスレポートとダッシュボード**  
  データベースや API からリアルタイム データを取得し、売上サマリー、KPI、財務実績レポートを生成します。

- **パーソナライズされた営業・マーケティング デック**  
  CRM やフォーム データを使用して顧客固有のピッチ デックを自動作成し、迅速な納品とブランドの一貫性を確保します。

- **教育コンテンツ**  
  学習教材、クイズ、コースサマリーを eラーニング プラットフォーム向けの構造化されたスライド デックに変換します。

- **データ・AI 活用インサイト**  
  自然言語処理や分析エンジンを活用し、生データや長文テキストを要約されたプレゼンテーションに変換します。

- **メディアベースのスライド**  
  アップロードされた画像、注釈付きスクリーンショット、またはビデオのキーフレームと説明文からプレゼンテーションを組み立てます。

- **ドキュメント変換**  
  Word 文書、PDF、フォーム入力を最小限の手作業で視覚的なプレゼンテーションに自動変換します。

- **開発者向け・技術ツール**  
  コードや Markdown コンテンツから直接、技術デモ、ドキュメント概要、変更履歴をスライド形式で作成します。

これらのワークフローを自動化することで、組織はコンテンツ作成をスケールし、一貫性を保ち、より戦略的な業務に割く時間を確保できます。

## **コードを書いてみましょう**

本例では、**[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/)** を選択しました。これは、包括的な機能セットと、プログラムでプレゼンテーションを扱う際の使いやすさが特徴です。

低レベルのライブラリとは異なり、Open XML 構造を直接操作する必要があり、コードが冗長で読みにくくなることがありますが、Aspose.Slides は高レベル API を提供します。ファイル形式の詳細を理解することなく、レイアウト、書式設定、データ バインディングといったプレゼンテーション ロジックに集中できます。

Aspose.Slides は商用ライブラリですが、[無料トライアル](https://releases.aspose.com/slides/cpp/) バージョンでも本記事のサンプルは完全に実行可能です。アイデアの検証、機能テスト、概念実証の構築など、ライセンスを取得する前に十分に活用できます。したがって、ライセンス購入のハードルなしに自動 PowerPoint 生成を試すことができます。

では、実際のコンテンツを使用したサンプル プレゼンテーションの作成手順を見ていきましょう。

### **タイトルスライドの作成**

まず新しいプレゼンテーションを作成し、メイン見出しとサブタイトルを持つタイトルスライドを追加します。
```cpp
auto presentation = MakeObject<Presentation>();

auto slide0 = presentation->get_Slide(0);

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Title);
slide0->set_LayoutSlide(layoutSlide);

auto titleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(0));
auto subtitleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(1));

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review – Q1 2025");
subtitleShape->get_TextFrame()->set_Text(u"Prepared for Executive Team");
```


![タイトルスライド](slide_0.png)

### **柱状グラフ付きスライドの追加**

次に、地域別売上実績を柱状グラフで示すスライドを作成します。
```cpp
auto layoutSlide1 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide1 = presentation->get_Slides()->AddEmptySlide(layoutSlide1);

auto chart = slide1->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 350, false);
chart->get_Legend()->set_Position(LegendPositionType::Bottom);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Data from January – March 2025");
chart->get_ChartTitle()->set_Overlay(false);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"North America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Europe")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Asia Pacific")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Latin America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 5, 0, ObjectExt::Box<String>(u"Middle East")));

auto series = chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Sales ($K)")), chart->get_Type());
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(480)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(365)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(290)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 1, ObjectExt::Box<int32_t>(150)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 5, 1, ObjectExt::Box<int32_t>(120)));
```


![チャート付きスライド](slide_1.png)

### **テーブル付きスライドの追加**

続いて、主要パフォーマンス指標を表形式で提示するスライドを追加します。
```cpp
auto layoutSlide2 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide2 = presentation->get_Slides()->AddEmptySlide(layoutSlide2);

auto columnWidths = MakeArray<double>({ 200, 100 });
auto rowHeights = MakeArray<double>({ 40, 40, 40, 40, 40 });

auto table = slide2->get_Shapes()->AddTable(200, 200, columnWidths, rowHeights);
table->get_Column(0)->idx_get(0)->get_TextFrame()->set_Text(u"Metric");
table->get_Column(1)->idx_get(0)->get_TextFrame()->set_Text(u"Value");
table->get_Column(0)->idx_get(1)->get_TextFrame()->set_Text(u"Total Revenue");
table->get_Column(1)->idx_get(1)->get_TextFrame()->set_Text(u"$1.4M");
table->get_Column(0)->idx_get(2)->get_TextFrame()->set_Text(u"Gross Margin");
table->get_Column(1)->idx_get(2)->get_TextFrame()->set_Text(u"54%");
table->get_Column(0)->idx_get(3)->get_TextFrame()->set_Text(u"New Customers");
table->get_Column(1)->idx_get(3)->get_TextFrame()->set_Text(u"340");
table->get_Column(0)->idx_get(4)->get_TextFrame()->set_Text(u"Customer Retention");
table->get_Column(1)->idx_get(4)->get_TextFrame()->set_Text(u"87%");
```


![テーブル付きスライド](slide_2.png)

### **箇条書きの要約スライドの追加**

最後に、シンプルな箇条書きリストを使用して要約とアクションプランを含めます。
```cpp
static SharedPtr<IParagraph> CreateBulletParagraph(String text) {
    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
    paragraph->get_ParagraphFormat()->set_Indent(15);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    paragraph->set_Text(text);
    return paragraph;
}
```

```cpp
auto layoutSlide3 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide3 = presentation->get_Slides()->AddEmptySlide(layoutSlide3);

auto bulletList = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 50, 600, 200);
bulletList->get_FillFormat()->set_FillType(FillType::NoFill);
bulletList->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

bulletList->get_TextFrame()->get_Paragraphs()->Clear();
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Strong performance in North America; growth opportunity in Asia Pacific"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Improve marketing outreach in underperforming regions"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Prepare new campaign strategy for Q2"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Schedule follow-up review in early July"));
```


![テキスト付きスライド](slide_3.png)

### **プレゼンテーションの保存**

最後に、プレゼンテーションをディスクに保存します:
```java
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **結論**

C++ アプリケーションにおける PowerPoint 生成の自動化は、時間削減と手作業の削減という明確なメリットを提供します。チャート、テーブル、テキストといった動的コンテンツを組み込むことで、開発者は一貫したプロフェッショナルなプレゼンテーションを迅速に作成でき、業務レポートやクライアントミーティング、教育コンテンツに最適です。

本記事では、タイトルスライド、チャート、テーブルを追加する一連の手順を示し、ゼロからプレゼンテーションを自動作成する方法をデモしました。このアプローチは、データ駆動型のプレゼンテーションが求められるさまざまなユースケースに適用可能です。

適切なツールを活用すれば、C++ 開発者は PowerPoint 作成を効率的に自動化でき、生産性を向上させ、プレゼンテーション全体の一貫性を確保できます。