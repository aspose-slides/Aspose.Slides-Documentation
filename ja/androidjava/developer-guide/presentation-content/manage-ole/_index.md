---
title: OLEの管理
type: docs
weight: 40
url: /ja/androidjava/manage-ole/
keywords:
- OLEを追加
- OLEを埋め込む
- オブジェクトを追加
- オブジェクトを埋め込む
- ファイルを埋め込む
- リンクされたオブジェクト
- オブジェクトリンクと埋め込み
- OLEオブジェクト
- PowerPoint 
- プレゼンテーション
- Android
- Java
- Aspose.Slides for Android via Java
description: JavaでPowerPointプレゼンテーションにOLEオブジェクトを追加します
---

{{% alert color="primary" %}} 

OLE（オブジェクトリンクと埋め込み）は、Microsoftの技術で、1つのアプリケーションで作成されたデータやオブジェクトをリンクまたは埋め込むことで別のアプリケーションに配置できるようにします。

{{% /alert %}} 

MS Excelで作成されたチャートを考えてください。そのチャートはPowerPointのスライドの中に配置されます。そのExcelチャートはOLEオブジェクトと見なされます。

- OLEオブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、そのチャートが関連付けられたアプリケーション（Excel）で開かれるか、オブジェクトを開くまたは編集するアプリケーションを選択するよう求められます。
- OLEオブジェクトは、実際のコンテンツを表示することがあります。たとえば、チャートのコンテンツです。この場合、チャートはPowerPointでアクティブになり、チャートインターフェースが読み込まれ、PowerPointアプリ内でチャートのデータを変更することができます。

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/)を使用すると、OLEオブジェクトをOLEオブジェクトフレームとしてスライドに挿入することができます（[OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)）。

## **スライドにOLEオブジェクトフレームを追加する**
Microsoft Excelでチャートをすでに作成していて、そのチャートをOLEオブジェクトフレームとしてスライドに埋め込みたい場合、以下のように行うことができます：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. Excelチャートオブジェクトを含むExcelファイルを開き、`MemoryStream`に保存します。
1. OLEオブジェクトに関するバイトの配列とその他の情報を含むスライドに[OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)を追加します。
1. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

以下の例では、ExcelファイルからスライドにOLEオブジェクトフレームとしてチャートを追加しました。
**注意**： [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IOleEmbeddedDataInfo)コンストラクターは、埋め込み可能なオブジェクト拡張子を2番目のパラメーターとして受け取ります。この拡張により、PowerPointはファイルタイプを正しく解釈し、このOLEオブジェクトを開くための適切なアプリケーションを選択できます。

``` java 
// PPTXファイルを表すPresentationクラスのインスタンスを生成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // ストリームにExcelファイルをロード
    FileInputStream fs = new FileInputStream("book1.xlsx");
    ByteArrayOutputStream mstream = new ByteArrayOutputStream();
    byte[] buf = new byte[4096];
    while (true)
    {
        int bytesRead = fs.read(buf, 0, buf.length);
        if (bytesRead <= 0)
            break;
        mstream.write(buf, 0, bytesRead);
    }
    fs.close();

    // 埋め込み用のデータオブジェクトを作成
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.toByteArray(), "xlsx");
    mstream.close();

    // Ole Object Frameシェイプを追加
    IOleObjectFrame oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0,
            (float) pres.getSlideSize().getSize().getWidth(),
            (float) pres.getSlideSize().getSize().getHeight(),
            dataInfo);

    // PPTXファイルをディスクに保存
    pres.save("OleEmbed_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **OLEオブジェクトフレームにアクセスする**
OLEオブジェクトがすでにスライドに埋め込まれている場合、そのオブジェクトを次のようにして簡単に見つけたりアクセスしたりすることができます：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. OLEオブジェクトフレームシェイプにアクセスします。

   私たちの例では、1つのシェイプしかない最初のスライドを持つ以前に作成したPPTXを使用しました。次に、そのオブジェクトを[OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)として*キャスト*しました。これがアクセスしたいOLEオブジェクトフレームでした。
1. OLEオブジェクトフレームにアクセスすると、その上で任意の操作を実行できます。

以下の例では、OLEオブジェクトフレーム（スライドに埋め込まれたExcelチャートオブジェクト）にアクセスし、そのファイルデータをExcelファイルに書き出します。

``` java 
// PPTXをPresentationオブジェクトに読み込む
Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx");
try {
    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // シェイプをOleObjectFrameにキャスト
    OleObjectFrame oleObjectFrame = (OleObjectFrame) sld.getShapes().get_Item(0);

    // OLEオブジェクトを読み込み、ディスクに書き込む
    if (oleObjectFrame != null) {
        // 埋め込まれたファイルデータを取得
        byte[] data = oleObjectFrame.getEmbeddedData().getEmbeddedFileData();

        // 埋め込まれたファイル拡張子を取得
        String fileExtention = oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension();

        // 抽出したファイルを保存するパスを作成
        String extractedPath = "excelFromOLE_out" + fileExtention;

        // 抽出データを保存
        FileOutputStream fstr = new FileOutputStream(extractedPath);
        try {
            fstr.write(data, 0, data.length);
        } finally {
            fstr.close();
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **OLEオブジェクトデータの変更**

OLEオブジェクトがすでにスライドに埋め込まれている場合、そのオブジェクトにアクセスしてデータを変更することができます。手順は以下の通りです：

1. 埋め込まれたOLEオブジェクトを持つプレゼンテーションを開くために、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。 
1. OLEオブジェクトフレームシェイプにアクセスします。

   私たちの例では、1つのシェイプを持つ以前に作成したPPTXを使用しました。次に、[OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)としてそのオブジェクトを*キャスト*しました。これがアクセスしたいOLEオブジェクトフレームでした。
1. OLEオブジェクトフレームにアクセスすると、その上で任意の操作を実行できます。
1. Workbookオブジェクトを作成し、OLEデータにアクセスします。
1. 必要なワークシートにアクセスし、データを修正します。
1. 更新したワークブックをストリームに保存します。
1. ストリームデータからOLEオブジェクトデータを変更します。

以下の例では、OLEオブジェクトフレーム（スライドに埋め込まれたExcelチャートオブジェクト）にアクセスし、そのファイルデータを変更してチャートデータを変更します：

``` java 
Presentation pres = new Presentation("ChangeOLEObjectData.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
	
    OleObjectFrame ole = null;

    // Oleフレームのためにすべてのシェイプをトラバース
    for (IShape shape : slide.getShapes()) 
    {
        if (shape instanceof OleObjectFrame) 
        {
            ole = (OleObjectFrame) shape;
        }
    }

    if (ole != null) {
        ByteArrayInputStream msln = new ByteArrayInputStream(ole.getEmbeddedData().getEmbeddedFileData());
        try {
            // Workbookでオブジェクトデータを読み込む
            Workbook Wb = new Workbook(msln);

            ByteArrayOutputStream msout = new ByteArrayOutputStream();
            try {
                // ワークブックデータを修正
                Wb.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
                Wb.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
                Wb.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
                Wb.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

                OoxmlSaveOptions so1 = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
                Wb.save(msout, so1);

                // Oleフレームオブジェクトデータを変更
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(msout.toByteArray(), ole.getEmbeddedData().getEmbeddedFileExtension());
                ole.setEmbeddedData(newData);
            } finally {
                if (msout != null) msout.close();
            }
        } finally {
            if (msln != null) msln.close();
        }
    }

    pres.save("OleEdit_out.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## スライドに他のファイルタイプを埋め込む

Excelチャートの他に、Aspose.Slides for Android via Javaを使用すると、スライドに他のタイプのファイルを埋め込むことができます。たとえば、HTML、PDF、ZIPファイルをオブジェクトとしてスライドに挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、オブジェクトが関連プログラムで自動的に起動するか、ユーザーがオブジェクトを開くための適切なプログラムを選択するように指示されます。

このJavaコードは、スライドにHTMLとZIPを埋め込む方法を示しています：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    byte[] htmlBytes = Files.readAllBytes(Paths.get("embedOle.html"));
    IOleEmbeddedDataInfo dataInfoHtml = new OleEmbeddedDataInfo(htmlBytes, "html");
    IOleObjectFrame oleFrameHtml = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, dataInfoHtml);
    oleFrameHtml.setObjectIcon(true);

    byte[] zipBytes = Files.readAllBytes(Paths.get("embedOle.zip"));
    IOleEmbeddedDataInfo dataInfoZip = new OleEmbeddedDataInfo(zipBytes, "zip");
    IOleObjectFrame oleFrameZip = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, dataInfoZip);
    oleFrameZip.setObjectIcon(true);

    pres.save("embeddedOle.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## 埋め込まれたオブジェクトのファイルタイプを設定する

プレゼンテーションを作成しているとき、古いOLEオブジェクトを新しいものに置き換える必要があるかもしれません。また、サポートされていないOLEオブジェクトをサポートされているものに置き換える必要があるかもしれません。

Aspose.Slides for Android via Javaを使用すると、埋め込まれたオブジェクトのファイルタイプを設定できます。この方法により、OLEフレームデータまたはその拡張子を変更できます。

このJavaコードは、埋め込まれたOLEオブジェクトのファイルタイプを設定する方法を示しています：

```java
Presentation pres = new Presentation("embeddedOle.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.getShapes().get_Item(0);
    System.out.println("現在の埋め込まれたデータ拡張子は: " + oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension());

    oleObjectFrame.setEmbeddedData(new OleEmbeddedDataInfo(Files.readAllBytes(Paths.get("embedOle.zip")), "zip"));

    pres.save("embeddedChanged.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## 埋め込まれたオブジェクトのアイコン画像とタイトルを設定する

OLEオブジェクトを埋め込むと、自動的にアイコン画像とタイトルで構成されるプレビューが追加されます。このプレビューは、ユーザーがOLEオブジェクトにアクセスする前に見るものです。

特定の画像とテキストをプレビューの要素として使用したい場合、Aspose.Slides for Android via Javaを使用してアイコン画像とタイトルを設定できます。

このJavaコードは、埋め込まれたオブジェクトのアイコン画像とタイトルを設定する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

        IPPImage oleImage;
        IImage image = Images.fromFile("image.png");
        try {
             oleImage = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    oleObjectFrame.setSubstitutePictureTitle("私のタイトル");
    oleObjectFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleObjectFrame.setObjectIcon(false);

    pres.save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **OLEオブジェクトフレームがサイズ変更および位置変更されないようにする**

リンクされたOLEオブジェクトをプレゼンテーションスライドに追加した後、PowerPointでプレゼンテーションを開くと、リンクを更新するよう求めるメッセージが表示される場合があります。「リンクを更新」ボタンをクリックすると、OLEオブジェクトフレームのサイズと位置が変更される可能性があります。なぜなら、PowerPointはリンクされたOLEオブジェクトからデータを更新し、オブジェクトのプレビューを更新するからです。PowerPointがオブジェクトのデータを更新するように促さないようにするには、[IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/)インターフェースの`setUpdateAutomatic`メソッドを`false`に設定します：

```java
oleObjectFrame.setUpdateAutomatic(false);
```

## 埋め込まれたファイルの抽出

Aspose.Slides for Android via Javaを使用すると、OLEオブジェクトとしてスライドに埋め込まれたファイルを次のように抽出できます：

1. 抽出したいOLEオブジェクトを含む[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのシェイプをループし、[OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe)シェイプにアクセスします。
3. OLEオブジェクトフレームから埋め込まれたファイルのデータにアクセスし、ディスクに書き込みます。

このJavaコードは、スライドに埋め込まれたファイルをOLEオブジェクトとして抽出する方法を示しています：

```java
Presentation pres = new Presentation("embeddedOle.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    for (int index = 0; index < slide.getShapes().size(); index++)
    {
        IShape shape = slide.getShapes().get_Item(index);
        IOleObjectFrame oleFrame = (IOleObjectFrame)shape;

        if (oleFrame != null) 
		{
            byte[] data = oleFrame.getEmbeddedData().getEmbeddedFileData();
            String extension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

            // 抽出したデータを保存
            FileOutputStream fstr = new FileOutputStream("oleFrame" + index + extension);
            try {
                fstr.write(data, 0, data.length);
            } finally {
                fstr.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```