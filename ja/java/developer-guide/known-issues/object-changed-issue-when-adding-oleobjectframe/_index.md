---
title: OleObjectFrameを追加した際のオブジェクト変更問題
type: docs
weight: 10
url: /java/object-changed-issue-when-adding-oleobjectframe/
---

## **問題の説明**
開発者がAspose.Slides for Javaを使用してスライドに**OleObjectFrame**を追加すると、出力スライドに**OLE Object**の代わりに**Object Changed**メッセージが表示されます。ほとんどのAspose.Slides for Javaの顧客は、これはAspose.Slides for Javaのバグまたはエラーだと考えています。
## **批判的分析と説明**
まず最初に、スライドに**OleObjectFrame**を追加した後にAspose.Slides for Javaによって表示される**Object Changed**メッセージは、Aspose.Slides for Javaのエラーやバグでは**ありません**。これは、オブジェクトが変更されたことをユーザーに通知する情報またはメッセージです。

例えば、スライドに**OleObjectFrame**として**Microsoft Excel Chart**を追加すると（**OleObjectFrame**をスライドに追加する際の詳細とコードスニペットについては、[こちらをクリック](/slides/java/adding-frame-to-the-slide/)）、次にそのプレゼンテーションファイルをMS PowerPointで開くと、スライド（**OLE Object**が追加された場所）は次のようになります：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

**図**: **OLE Object**が追加された後に**Object Changed**メッセージを表示するスライド

これはエラーではなく、OLEオブジェクトは依然としてスライドに追加されています。これをテストしたい場合は、**Object Changed**メッセージを**ダブルクリック**するか、右クリックして次のように**Worksheet Object -> Edit**オプションを選択します：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

**図**: **OLE Object**を編集するための**Edit**オプションを選択

ポップアップメニューの**Edit**オプションを選択すると、**Embedded OLE Object**がeditableな形式で表示されることがわかります：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)

**図**: 編集可能な形式の**OLE Object**

MS PowerPointの**左ペイン**には、スライドのプレビューが表示される際に、依然として**Object Changed**メッセージが表示されます。**OLE Object**をクリックすると、スライドのプレビューも変更され、**Changed Object**メッセージが**OLE Object**の画像に置き換えられます：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

**図**: **OLE Object**画像の更新

今、あなたはMS PowerPointを使用してプレゼンテーションファイルを**保存**する必要があります。これにより、**OLE Object**の画像が更新されます。プレゼンテーションを保存して再度MS PowerPointで開くと、**Object Changed**メッセージが表示されなくなります。
## **さらなる解決策**
上記の批判的分析では、MS PowerPointでプレゼンテーションファイルを開いて保存することで、**OLE Object**の画像を更新できることを示しました。しかし、**Object Changed**メッセージに対処するための2つの解決策があります。
## **1つ目の解決策: オブジェクト変更メッセージを画像に置き換える**
**Object Changed**メッセージが気に入らない場合は、そのメッセージを自分の画像に置き換えることもできます。プレゼンテーションに任意の画像を追加し、その追加した画像のIDを使用して**Object Changed**メッセージを置き換えることができます。

これを実現するために、スライドに**OleObjectFrame**を追加した後、アプリケーションにこれらのコードの行を追加することができます。
## **例**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ReplacingObjectChangedMessageWithAnImage-ReplacingObjectChangedMessageWithAnImage.java" >}}

上記の行をアプリケーションに追加した後、**OleObjectFrame**を含むスライドは次のようになります：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

**図**: 画像で置き換えられた**Object Changed**メッセージ
## **2つ目の解決策: MS PowerPoint用のアドオンを作成する**
MS PowerPoint用のアドオンを作成し、プレゼンテーションをMS PowerPointで開いたときにすべての**OLEオブジェクト**を更新することも試すことができます。