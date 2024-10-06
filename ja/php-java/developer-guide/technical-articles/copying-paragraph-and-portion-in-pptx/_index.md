---
title: PPTX内の段落と部分のコピー
type: docs
weight: 70
url: /ja/php-java/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

プレゼンテーションのテキストをフォーマットするためには、**段落**と**部分**レベルでフォーマットする必要があります。段落レベルで設定できるテキストプロパティと、部分レベルで設定できるテキストプロパティがあります。新しく追加された段落や部分にコピーする必要があるテキスト内の段落や部分がある場合、対応する段落または部分のすべてのプロパティを新しく追加された段落または部分にコピーする必要があります。

{{% /alert %}} 
## **段落のコピー**
**段落**のプロパティは、**Paragraph**クラスの**ParagraphFormat**インスタンスでアクセスできます。ソース段落のすべてのプロパティをターゲット段落にコピーする必要があります。以下の例では、コピーする段落を引数として受け取る**CopyParagraph**メソッドが共有されています。このメソッドは、ソース段落のすべてのプロパティを一時的な段落にコピーし、同じものを返します。ターゲット段落は、コピーされた値を取得します。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyParagraph-CopyParagraph.java" >}}


## **部分のコピー**
**部分**のプロパティは、**Portion**クラスの**PortionFormat**インスタンスでアクセスできます。ソース部分のすべてのプロパティをターゲット部分にコピーする必要があります。以下の例では、コピーする部分を引数として受け取る**CopyPortion**メソッドが共有されています。このメソッドは、ソース部分のすべてのプロパティを一時的な部分にコピーし、同じものを返します。ターゲット部分は、コピーされた値を取得します。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyPortion-CopyPortion.java" >}}