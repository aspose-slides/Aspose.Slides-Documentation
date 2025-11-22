---
title: 部分
type: docs
weight: 70
url: /ja/nodejs-java/portion/
---

## **部分の位置座標を取得**
[**getCoordinates()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getCoordinates--) メソッドが [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) クラスに追加され、部分の開始位置の座標を取得できるようになりました。
```javascript
// PPTX を表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // プレゼンテーションのコンテキストを再構築
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**単一の段落内のテキストの一部だけにハイパーリンクを適用できますか？**

はい、[ハイパーリンクを割り当てる](/slides/ja/nodejs-java/manage-hyperlinks/) を個々の部分に割り当てることができます。そのフラグメントだけがクリック可能となり、段落全体はクリックできません。

**スタイル継承はどのように機能しますか：Portion が上書きするものは何で、Paragraph/TextFrame から取得されるものは何ですか？**

Portion レベルのプロパティが最も高い優先順位を持ちます。プロパティが [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) に設定されていない場合、エンジンは [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) から取得します。そこにも設定がない場合は、[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) または [theme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/theme/) のスタイルから取得します。

**Portion に指定されたフォントが対象のマシン/サーバーに存在しない場合、どうなりますか？**

[フォント置換ルール](/slides/ja/nodejs-java/font-selection-sequence/) が適用されます。テキストは再フローする可能性があり、メトリクス、ハイフネーション、幅が変わることがあり、正確な位置決めに影響します。

**段落全体とは独立して、Portion 固有のテキストの塗りつぶしの透明度やグラデーションを設定できますか？**

はい、[Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) レベルでテキストの色、塗りつぶし、透明度を隣接するフラグメントと異なる設定にできます。