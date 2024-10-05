---
title: OleObjectFrameを追加した際のオブジェクト変更問題
type: docs
weight: 10
url: /php-java/object-changed-issue-when-adding-oleobjectframe/
---

## **問題の説明**
開発者がAspose.Slides for PHP via Javaを使用してスライドに**OleObjectFrame**を追加すると、出力スライドに**OLEオブジェクト**の代わりに**オブジェクト変更**メッセージが表示されます。ほとんどのAspose.Slides for PHP via Javaの顧客は、これはバグやエラーだと考えています。
## **批評分析と説明**
まず初めに、スライドに**OleObjectFrame**を追加した後にAspose.Slides for PHP via Javaが表示する**オブジェクト変更**メッセージは、Aspose.Slides for PHP via Javaのエラーやバグではないことを知ることが重要です。これは、オブジェクトが変更され、画像を更新する必要があることをユーザーに通知するための情報やメッセージです。

例えば、スライドに**OleObjectFrame**として**Microsoft Excel Chart**を追加すると（スライドに**OleObjectFrame**を追加する詳細とコードスニペットについては[こちらをクリック](/slides/php-java/adding-frame-to-the-slide/)）、その後MS PowerPointを使ってプレゼンテーションファイルを開くと、**OLEオブジェクト**が追加されたスライドは次のようになります：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

**図**: **OLEオブジェクト**が追加された後の**オブジェクト変更**メッセージを表示するスライド

これはエラーではなく、OLEオブジェクトはまだスライドに追加されています。これをテストしたい場合は、**オブジェクト変更**メッセージを**ダブルクリック**するか、右クリックして**ワークシートオブジェクト -> 編集**オプションを選択してください。以下の図のようになります：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

**図**: **OLEオブジェクト**を編集するための**編集**オプションを選択

ポップアップメニューの**編集**オプションを選択すると、**埋め込みOLEオブジェクト**が編集可能な形式で表示されます。以下のようになります：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)

**図**: 編集可能な形式の**OLEオブジェクト**

MS PowerPointのスライドプレビューを表示する**左ペイン**にはまだ**オブジェクト変更**メッセージが表示されます。**OLEオブジェクト**をクリックすると、スライドプレビューが変更され、**変更されたオブジェクト**メッセージが**OLEオブジェクト**の画像に置き換わります。以下のようになります：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

**図**: **OLEオブジェクト**画像の更新

今、MS PowerPointを使用してプレゼンテーションファイルを**保存**し、OLEオブジェクトの画像を更新する必要があります。一度プレゼンテーションを保存して再度MS PowerPointを使って開くと、**オブジェクト変更**メッセージが表示されなくなります。
## **さらに解決策**
上記の批評分析では、MS PowerPointでプレゼンテーションファイルを開いて保存することで**OLEオブジェクト**の画像が更新されることを示しました。しかし、**オブジェクト変更**メッセージに対処するための解決策は2つあります。
## **1つ目の解決策: オブジェクト変更メッセージを画像で置き換える**
**オブジェクト変更**メッセージが気に入らない場合は、そのメッセージを自分の画像で置き換えることもできます。希望の画像をプレゼンテーションに追加し、追加した画像のIDを使用して**オブジェクト変更**メッセージを置き換えることができます。

これを実現するには、スライドに**OleObjectFrame**を追加した後、この数行のコードをアプリケーションに追加します。
## **例**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ReplacingObjectChangedMessageWithAnImage-ReplacingObjectChangedMessageWithAnImage.java" >}}

上記のコードをアプリケーションに追加した後、**OleObjectFrame**を含む結果のスライドは次のようになります：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

**図**: 画像で置き換えられた**オブジェクト変更**メッセージ
## **2つ目の解決策: MS PowerPoint用のアドオンを作成する**
MS PowerPointのアドオンを作成して、プレゼンテーションをMS PowerPointで開いたときにすべての**OLEオブジェクト**を更新することも試みることができます。