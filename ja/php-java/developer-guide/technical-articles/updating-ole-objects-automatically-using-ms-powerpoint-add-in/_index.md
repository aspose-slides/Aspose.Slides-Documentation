---
title: MS PowerPointアドインを使用してOLEオブジェクトを自動で更新する
type: docs
weight: 10
url: /php-java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
---

## **OLEオブジェクトを自動で更新することについて**
Aspose.Slidesの顧客からよく寄せられる質問の一つは、編集可能なグラフやその他のOLEオブジェクトを作成または変更し、プレゼンテーションを開いたときに自動的に更新されるようにする方法です。残念ながら、PowerPointはExcelやWordで利用可能な自動マクロをサポートしていません。利用可能なのはAuto_OpenおよびAuto_Closeマクロのみです。しかし、これらはアドインからのみ自動的に実行されます。この短い技術的ヒントでは、その方法を示します。

まず、Auto_Openマクロ機能をPowerPointに追加するいくつかのフリーウェアアドインがあります。たとえば、[AutoEvents Add-in](http://skp.mvps.org/autoevents.htm)や[Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html)です。

そのようなアドインをインストールした後、以下のようにテンプレートプレゼンテーションにAuto_Open()マクロ（「Event Generator」の場合はOnPresentationOpen()）を追加します：

{{< gist "mannanfazil" "c31114d3fe29596f0a53817b8f8705ac" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-UpdateOLEObject-UpdateOLEObject.java" >}}





{{% alert color="primary" %}} 

Aspose.Slidesを使用してOLEオブジェクトに加えた変更は、PowerPointがプレゼンテーションを開くと自動的に更新されます。プレゼンテーションに多数のOLEオブジェクトがあり、すべてを更新したくない場合は、処理する必要のある図形にカスタムタグを追加し、マクロ内でチェックしてください。 

{{% /alert %}}