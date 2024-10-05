---
title: OleObjectFrameを追加する際のオブジェクト変更問題
type: docs
weight: 10
url: /net/object-changed-issue-when-adding-oleobjectframe/
---

{{% alert color="primary" %}} 

Aspose.Slides for .NETを使用して、スライドに**[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)**を追加すると、出力スライドに**オブジェクトが変更されました**というメッセージが表示されます（OLEオブジェクトには表示されません）。ここで説明するプロセスは意図的なものであり、バグではありません。

OLEオブジェクトの操作に関する詳細は、[OLEを管理する](/slides/net/manage-ole/)を参照してください。

{{% /alert %}} 
## **説明**と解決策
Aspose.Slidesは、OLEオブジェクトが変更され、プレビュー画像を更新する必要があることを通知するために**オブジェクトが変更されました**というメッセージを表示します。

たとえば、Microsoft Excelのチャートをスライドに**[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)**として追加し（詳細はOLEを管理する記事を参照）、その後プレゼンテーションをMicrosoft PowerPointアプリで開くと、スライドにこの画像が表示されます：

~~すべての画像を新しい画像に置き換える~~

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

OLEオブジェクトがスライドに追加されたことを確認したい場合は、**オブジェクトが変更されました**というメッセージをダブルクリックするか、右クリックして**ワークシートオブジェクト > 編集オプション**を選択する必要があります。

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

PowerPointは埋め込まれたOLEオブジェクトを開きます。

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)

スライドには**オブジェクトが変更されました**というメッセージが残る場合があります。OLEオブジェクトをクリックすると、スライドのプレビューが更新され、**オブジェクトが変更されました**というメッセージがOLEオブジェクトの実際の画像に置き換わります。

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

今、OLEオブジェクトの画像が正しく更新されるようにプレゼンテーションを保存したいかもしれません。この方法でプレゼンテーションを保存した後、再度プレゼンテーションを開くと、**オブジェクトが変更されました**というメッセージは表示されません。

## **その他の解決策**
### **解決策 1: オブジェクトが変更されましたメッセージを画像と置き換える**

PowerPointでプレゼンテーションを開いて保存することにより、**オブジェクトが変更されました**というメッセージを削除したくない場合は、メッセージを好みのプレビュー画像で置き換えることができます。以下のコードは、そのプロセスを示しています。

``` csharp 
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
   ISlide slide = pres.Slides[0];
   IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];
    
   IPPImage oleImage = pres.Images.AddImage(File.ReadAllBytes("my_image.png"));
   oleObjectFrame.SubstitutePictureTitle = "私のタイトル";
   oleObjectFrame.SubstitutePictureFormat.Picture.Image = oleImage;
   oleObjectFrame.IsObjectIcon = false;
    
   pres.Save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
}
```

`OleObjectFrame`を含むスライドは次のように変わります。

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

### **解決策 2: PowerPoint用のアドオンを作成する**
プレゼンテーションをプログラムで開いたときにすべてのOLEオブジェクトを更新するMicrosoft PowerPoint用のアドオンを作成することもできます。