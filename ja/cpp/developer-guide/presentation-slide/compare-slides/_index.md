---
title: スライドの比較
type: docs
weight: 50
url: /ja/cpp/compare-slides/
---

## **2つのスライドを比較する**
EqualsメソッドがIBaseSlideインターフェースとBaseSlideクラスに追加されました。このメソッドは、構造と静的コンテンツが同一のスライド/レイアウトスライド/マスタースライドに対してtrueを返します。

2つのスライドは、すべてのシェイプ、スタイル、テキスト、アニメーションおよびその他の設定が等しい場合に等しいと見なされます。比較では、SlideIdのようなユニークな識別子の値や、Date Placeholder内の日付のような動的コンテンツは考慮されません。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}