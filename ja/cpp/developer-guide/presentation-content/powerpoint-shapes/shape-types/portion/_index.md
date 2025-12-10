---
title: C++ を使用したプレゼンテーションのテキスト部分の管理
linktitle: テキスト部分
type: docs
weight: 70
url: /ja/cpp/portion/
keywords:
- テキスト部分
- テキストパート
- テキスト座標
- テキスト位置
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint プレゼンテーションのテキスト部分を管理し、パフォーマンスとカスタマイズ性を向上させる方法を学びます。"
---

## **テキスト部分の座標を取得**
**GetCoordinates()** メソッドが IPortion と Portion クラスに追加され、部分の開始位置の座標を取得できるようになりました:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```


## **よくある質問**

**単一の段落内のテキストの一部だけにハイパーリンクを適用できますか？**

はい、個々の Portion に対して[ハイパーリンクを割り当て](/slides/ja/cpp/manage-hyperlinks/) できます。そのフラグメントだけがクリック可能となり、段落全体はクリックできません。

**スタイル継承はどのように機能しますか: Portion が上書きするものは何で、Paragraph/TextFrame から取得されるものは何ですか？**

Portion レベルのプロパティが最も優先されます。プロパティが[Portion](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)に設定されていない場合、エンジンは[Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/)から取得します。そちらにも設定がなければ、[TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/)または[theme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/theme/)のスタイルから取得します。

**Portion に指定されたフォントが対象のマシン/サーバーに存在しない場合はどうなりますか？**

[フォント置換ルール](/slides/ja/cpp/font-selection-sequence/)が適用されます。テキストの再フローが起こる可能性があり、メトリック、ハイフネーション、幅が変わるため、正確な位置決めに影響します。

**段落全体とは別に、Portion 固有のテキスト塗りつぶしの透明度やグラデーションを設定できますか？**

はい、[Portion](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)レベルでテキストの色、塗りつぶし、透明度を隣接するフラグメントと異なる設定にできます。