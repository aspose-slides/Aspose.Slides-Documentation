---
title: OLEの管理
type: docs
weight: 40
url: /ja/java/manage-ole/
keywords:
- OLEの追加
- OLEの埋め込み
- オブジェクトの追加
- オブジェクトの埋め込み
- ファイルの埋め込み
- リンクオブジェクト
- オブジェクトリンクと埋め込み
- OLEオブジェクト
- PowerPoint 
- プレゼンテーション
- Java
- Aspose.Slides for Java
description: JavaでPowerPointプレゼンテーションにOLEオブジェクトを追加する
---

{{% alert color="primary" %}} 

OLE（Object Linking & Embedding）は、Microsoftの技術で、1つのアプリケーションで作成されたデータやオブジェクトをリンクまたは埋め込みを通じて別のアプリケーションに配置できるようにします。

{{% /alert %}} 

MS Excelで作成されたグラフを考えてみましょう。そのグラフはPowerPointスライドの中に配置されます。そのExcelグラフはOLEオブジェクトと見なされます。

- OLEオブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、関連付けられたアプリケーション（Excel）でグラフが開かれたり、オブジェクトの開くまたは編集するアプリケーションを選択するように求められたりします。
- OLEオブジェクトは実際の内容を表示することもあります。たとえば、グラフの内容です。この場合、グラフはPowerPointでアクティブになり、グラフインターフェースが読み込まれ、PowerPointアプリ内でグラフのデータを修正できます。

[Aspose.Slides for Java](https://products.aspose.com/slides/java/)を使用すると、OLEオブジェクトフレーム（[OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)）としてスライドにOLEオブジェクトを挿入できます。

## **スライドへのOLEオブジェクトフレームの追加**
Microsoft Excelでグラフをすでに作成し、そのグラフをOLEオブジェクトフレームとしてスライドに埋め込みたいと仮定します。次の方法で行えます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. Excelグラフオブジェクトを含むExcelファイルを開き、`MemoryStream`に保存します。
1. OLEオブジェクトに関するバイトの配列とその他の情報を含むスライドに[OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)を追加します。
1. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、ExcelファイルからスライドにOLEオブジェクトフレームとしてグラフを追加しました。  
**注意**として、[IOleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IOleEmbeddedDataInfo)コンストラクターは、埋め込み可能なオブジェクト拡張子を2番目のパラメーターとして受け取ります。この拡張子により、PowerPointはファイルタイプを正しく解釈し、このOLEオブジェクトを開くための適切なアプリケーションを選択することができます。

``` java 
// PPTXファイルを表すPresentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // ストリームにExcelファイルを読み込む
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

    // Oleオブジェクトフレームを追加
    IOleObjectFrame oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0,
            (float) pres.getSlideSize().getSize().getWidth(),
            (float) pres.getSlideSize().getSize().getHeight(),
            dataInfo);

    // PPTXファイルをディスクに書き込む
    pres.save("OleEmbed_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **OLEオブジェクトフレームへのアクセス**
スライドにOLEオブジェクトがすでに埋め込まれている場合、次の方法でそのオブジェクトを簡単に見つけたりアクセスしたりできます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. OLEオブジェクトフレームの形状にアクセスします。

   この例では、1枚目のスライドにのみ1つの形状がある以前に作成されたPPTXを使用しました。そして、そのオブジェクトを[OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)として*キャスト*しました。これがアクセスする必要があるOLEオブジェクトフレームです。
1. OLEオブジェクトフレームにアクセスしたら、その上で任意の操作を行うことができます。

以下の例では、OLEオブジェクトフレーム（スライドに埋め込まれたExcelグラフオブジェクト）にアクセスし、そのファイルデータがExcelファイルに書き込まれます。

``` java 
// PPTXをPresentationオブジェクトに読み込む
Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx");
try {
    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // 形状をOleObjectFrameにキャスト
    OleObjectFrame oleObjectFrame = (OleObjectFrame) sld.getShapes().get_Item(0);

    // OLEオブジェクトを読み取り、ディスクに書き込む
    if (oleObjectFrame != null) {
        // 埋め込まれたファイルデータを取得
        byte[] data = oleObjectFrame.getEmbeddedData().getEmbeddedFileData();

        // 埋め込まれたファイルの拡張子を取得
        String fileExtention = oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension();

        // 抽出されたファイルを保存するパスを作成
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

スライドにすでにOLEオブジェクトが埋め込まれている場合、そのオブジェクトに簡単にアクセスしてデータを修正できます。このようにして行います：

1. 埋め込まれたOLEオブジェクトを持つプレゼンテーションを開くために[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを介してスライドの参照を取得します。
1. OLEオブジェクトフレームの形状にアクセスします。

   この例では、最初のスライドにのみ1つの形状がある以前に作成されたPPTXを使用しました。そして、そのオブジェクトを[OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)として*キャスト*しました。これがアクセスする必要があるOLEオブジェクトフレームです。
1. OLEオブジェクトフレームにアクセスしたら、その上で任意の操作を行うことができます。
1. Workbookオブジェクトを作成し、OLEデータにアクセスします。
1. 必要なワークシートにアクセスしてデータを修正します。
1. 更新されたWorkbookをストリームに保存します。
1. ストリームデータからOLEオブジェクトデータを変更します。

以下の例では、OLEオブジェクトフレーム（スライドに埋め込まれたExcelグラフオブジェクト）にアクセスし、そのファイルデータが修正されてグラフデータが変更されます：

``` java 
Presentation pres = new Presentation("ChangeOLEObjectData.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
	
    OleObjectFrame ole = null;

    // Oleフレームのためにすべての形状を走査
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
            // Workbookでオブジェクトデータを読み取る
            Workbook Wb = new Workbook(msln);

            ByteArrayOutputStream msout = new ByteArrayOutputStream();
            try {
                // Workbookデータを修正
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

Excelグラフの他に、Aspose.Slides for Javaを使用すると、スライドに他のタイプのファイルを埋め込むことができます。たとえば、HTML、PDF、ZIPファイルをオブジェクトとしてスライドに挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、オブジェクトは自動的に関連するプログラムで起動されるか、ユーザーはオブジェクトを開くための適切なプログラムを選択するように促されます。

このJavaコードは、HTMLとZIPをスライドに埋め込む方法を示しています：

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

## 埋め込まれたオブジェクトのファイルタイプの設定

プレゼンテーションを作成しているとき、古いOLEオブジェクトを新しいものと置き換えたり、サポートされていないOLEオブジェクトをサポートされているものと置き換えたりする必要があるかもしれません。

Aspose.Slides for Javaは、埋め込まれたオブジェクトのファイルタイプを設定することを可能にします。このようにして、OLEフレームデータやその拡張子を変更することができます。

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

## 埋め込まれたオブジェクトのアイコン画像とタイトルの設定

OLEオブジェクトを埋め込むと、自動的にアイコン画像とタイトルからなるプレビューが追加されます。このプレビューは、ユーザーがOLEオブジェクトにアクセスまたは開く前に見るものです。

特定の画像とテキストをプレビュー内の要素として使用したい場合は、Aspose.Slides for Javaを使用してアイコン画像とタイトルを設定できます。

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

## **OLEオブジェクトフレームのサイズ変更および再配置を防ぐ**

リンクされたOLEオブジェクトをプレゼンテーションスライドに追加した後、プレゼンテーションをPowerPointで開くと、リンクを更新するように求められるメッセージが表示されることがあります。「リンクを更新」ボタンをクリックすると、OLEオブジェクトフレームのサイズと位置が変更されることがあります。これは、PowerPointがリンクされたOLEオブジェクトからデータを更新し、オブジェクトのプレビューを更新するためです。オブジェクトのデータを更新するようにPowerPointに促させないようにするには、[IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/)インターフェースの`setUpdateAutomatic`メソッドを`false`に設定します：

```java
oleObjectFrame.setUpdateAutomatic(false);
```

## 埋め込まれたファイルの抽出

Aspose.Slides for Javaを使用すると、OLEオブジェクトとしてスライドに埋め込まれたファイルを次のように抽出できます：

1. 抽出するOLEオブジェクトを含む[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. プレゼンテーション内のすべての形状をループして、[OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe)形状にアクセスします。
3. OLEオブジェクトフレームから埋め込まれたファイルのデータにアクセスし、ディスクに書き込みます。

このJavaコードは、OLEオブジェクトとしてスライドに埋め込まれたファイルを抽出する方法を示しています：

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

            // 抽出データを保存
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