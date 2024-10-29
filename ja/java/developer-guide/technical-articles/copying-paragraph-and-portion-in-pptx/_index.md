---
title: PPTXにおける段落と部分のコピー
type: docs
weight: 70
url: /ja/java/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

プレゼンテーションテキストをフォーマットするには、**段落**と**部分**のレベルでフォーマットする必要があります。段落レベルで設定できるテキストプロパティがいくつかあり、部分レベルで設定できるものもあります。新たに追加された段落や部分にコピーする必要があるテキスト内の段落または部分がある場合、対応する段落または部分のすべてのプロパティを新しく追加された段落または部分にコピーする必要があります。

{{% /alert %}} 
## **段落のコピー**
**段落**のプロパティは、**段落**クラスの**ParagraphFormat**インスタンスでアクセスできます。ソース段落のすべてのプロパティをターゲット段落にコピーする必要があります。以下の例では、コピーされる段落を引数として受け取る**CopyParagraph**メソッドが共有されています。このメソッドは、ソース段落のすべてのプロパティを一時的な段落にコピーし、それを返します。ターゲット段落はコピーされた値を取得します。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyParagraph-CopyParagraph.java" >}}

## **部分のコピー**
**部分**のプロパティは、**部分**クラスの**PortionFormat**インスタンスでアクセスできます。ソース部分のすべてのプロパティをターゲット部分にコピーする必要があります。以下の例では、コピーされる部分を引数として受け取る**CopyPortion**メソッドが共有されています。このメソッドは、ソース部分のすべてのプロパティを一時的な部分にコピーし、それを返します。ターゲット部分はコピーされた値を取得します。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyPortion-CopyPortion.java" >}}