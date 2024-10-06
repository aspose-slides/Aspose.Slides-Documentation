---  
title: MS PowerPoint アドインを使用して OLE オブジェクトを自動的に更新  
type: docs  
weight: 10  
url: /ja/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/  
---  
  
## **OLE オブジェクトを自動的に更新することについて**  
Aspose.Slides の顧客からよく寄せられる質問の一つは、編集可能なチャートやその他の OLE オブジェクトを作成または変更し、それらがプレゼンテーションを開く際に自動的に更新されるようにする方法です。残念ながら、PowerPoint は Excel や Word で利用可能な自動マクロをサポートしていません。利用可能なのは、Auto_Open と Auto_Close マクロのみです。しかし、それらはアドインからのみ自動的に実行されます。この短い技術的ヒントでは、その方法を示します。  

まず、PowerPoint に Auto_Open マクロ機能を追加するいくつかのフリーウェアアドインが利用可能です。例えば、[AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) および [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html) があります。  

そのようなアドインをインストールした後、以下に示すように、テンプレートプレゼンテーションに Auto_Open() マクロ（"Event Generator" の場合は OnPresentationOpen()）を追加します：  

{{< gist "mannanfazil" "c31114d3fe29596f0a53817b8f8705ac" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-UpdateOLEObject-UpdateOLEObject.java" >}}  

{{% alert color="primary" %}}  

Aspose.Slides で OLE オブジェクトに加えた変更は、PowerPoint がプレゼンテーションを開くと自動的に更新されます。プレゼンテーションに多くの OLE オブジェクトがあり、すべてを更新したくない場合は、処理が必要な図形にカスタムタグを追加し、マクロでそれをチェックしてください。  

{{% /alert %}}  