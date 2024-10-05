---
title: OleObjectFrameを追加した際のオブジェクト変更問題
type: docs
weight: 10
url: /androidjava/object-changed-issue-when-adding-oleobjectframe/
---

## **問題の説明**
開発者がAspose.Slides for Android via Javaを使用してスライドに**OleObjectFrame**を追加すると、出力スライドに**OLEオブジェクト**の代わりに**オブジェクト変更**メッセージが表示されます。Aspose.Slides for Android via Javaのほとんどの顧客は、これがAspose.Slides for Android via Javaのバグまたはエラーだと考えています。

## **批評分析と説明**
まず最初に、**OleObjectFrame**をスライドに追加した後にAspose.Slides for Android via Javaによって表示される**オブジェクト変更**メッセージは、Aspose.Slides for Android via Javaのエラーやバグでは**ありません**。これはユーザーにオブジェクトが変更され、画像を更新する必要があることを通知する情報やメッセージです。

例えば、スライドに**Microsoft Excelチャート**を**OleObjectFrame**として追加した場合（**OleObjectFrame**をスライドに追加する詳細とコードスニペットについては、[こちらをクリック](/slides/androidjava/adding-frame-to-the-slide/)）その後、MS PowerPointを使用してプレゼンテーションファイルを開くと、**OLEオブジェクト**が追加されたスライドは以下のようになります。

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

**図**: **OLEオブジェクト**が追加された後の**オブジェクト変更**メッセージを表示するスライド

これはエラーではなく、OLEオブジェクトはまだスライドに追加されています。これをテストしたい場合は、**オブジェクト変更**メッセージを**ダブルクリック**するか、右クリックして**ワークシートオブジェクト -> 編集**オプションを選択すると、以下の図のように表示されます。

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

**図**: **OLEオブジェクト**を編集するための**編集**オプションを選択

ポップアップメニューの**編集**オプションを選択すると、**埋め込まれたOLEオブジェクト**が編集可能な形で表示されるようになります。

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)

**図**: 編集可能な形の**OLEオブジェクト**

MS PowerPointのスライドプレビューを表示する**左ペイン**にまだ**オブジェクト変更**メッセージが表示されています。**OLEオブジェクト**をクリックすると、スライドプレビューも変更され、**変更されたオブジェクト**メッセージが**OLEオブジェクト**の画像に置き換わります。

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

**図**: **OLEオブジェクト**画像の更新

今、MS PowerPointを使用してプレゼンテーションファイルを**保存**する必要があります。そうすれば、**OLEオブジェクト**の画像が更新されます。プレゼンテーションを保存し、再度MS PowerPointで開くと、**オブジェクト変更**メッセージは表示されなくなります。

## **さらなる解決策**
上記の批評分析では、**OLEオブジェクト**の画像はMS PowerPointでプレゼンテーションファイルを開いた後に保存することによって更新できることを示しました。しかし、**オブジェクト変更**メッセージに対処するための解決策が2つあります。

## **1つ目の解決策: オブジェクト変更メッセージを画像に置き換える**
**オブジェクト変更**メッセージが気に入らない場合は、そのメッセージを任意の画像に置き換えることもできます。プレゼンテーションにお好みの画像を追加し、その追加した画像のIDを使用して**オブジェクト変更**メッセージを置き換えます。

これを実現するには、スライドに**OleObjectFrame**を追加した後にアプリケーション内に以下の数行のコードを追加できます。

## **例**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ReplacingObjectChangedMessageWithAnImage-ReplacingObjectChangedMessageWithAnImage.java" >}}

上記の行をアプリケーションに追加すると、**OleObjectFrame**を含む結果のスライドは以下のようになります。

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

**図**: 画像に置き換えられた**オブジェクト変更**メッセージ

## **2つ目の解決策: MS PowerPoint用のアドオンを作成する**
MS PowerPointのプレゼンテーションを開くときにすべての**OLEオブジェクト**を更新するアドオンを作成することも試みることができます。