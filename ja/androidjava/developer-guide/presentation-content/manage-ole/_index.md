---
title: Android でのプレゼンテーションにおける OLE の管理
linktitle: OLE の管理
type: docs
weight: 40
url: /ja/androidjava/manage-ole/
keywords:
- OLE オブジェクト
- オブジェクト リンキング & 埋め込み
- OLE を追加
- OLE を埋め込み
- オブジェクトを追加
- オブジェクトを埋め込み
- ファイルを追加
- ファイルを埋め込み
- リンクされたオブジェクト
- リンクされたファイル
- OLE を変更
- OLE アイコン
- OLE タイトル
- OLE を抽出
- オブジェクトを抽出
- ファイルを抽出
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument ファイル内の OLE オブジェクト管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---

{{% alert color="primary" %}} 

OLE（Object Linking & Embedding）は、1つのアプリケーションで作成されたデータやオブジェクトを、リンクや埋め込みにより別のアプリケーションに配置できる Microsoft の技術です。 

{{% /alert %}} 

Microsoft Excel で作成したチャートを考えてみてください。そのチャートを PowerPoint のスライドに配置します。この Excel のチャートは OLE オブジェクトとみなされます。 

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、チャートは対応するアプリケーション（Excel）で開かれるか、オブジェクトの開閉や編集に使用するアプリケーションの選択が求められます。 
- OLE オブジェクトは実際の内容（例えばチャートの内容）を表示することもあります。この場合、PowerPoint でチャートがアクティブになり、チャートインターフェイスがロードされ、PowerPoint 内でチャートのデータを変更できます。 

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) を使用すると、スライドに OLE オブジェクトを OLE オブジェクトフレーム（[OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)）として挿入できます。 

## **スライドに OLE オブジェクトフレームを追加** 

Microsoft Excel で既にチャートを作成し、Aspose.Slides for Android via Java を使用して OLE オブジェクトフレームとしてスライドに埋め込みたい場合は、次の手順で実行できます： 

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。 
1. インデックスを使用してスライドの参照を取得します。 
1. Excel ファイルをバイト配列として読み取ります。 
1. バイト配列と OLE オブジェクトに関するその他の情報を含む [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) をスライドに追加します。 
1. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。 

以下の例では、Excel ファイルからチャートを取得し、Aspose.Slides for Android via Java を使用して OLE オブジェクトフレームとしてスライドに追加しています。  
**Note** that the [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.  
```java 
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **リンクされた OLE オブジェクトフレームを追加** 

Aspose.Slides for Android via Java を使用すると、データを埋め込まずにファイルへのリンクだけで [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) を追加できます。  

以下の Java コードは、リンクされた Excel ファイルを持つ [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) をスライドに追加する方法を示しています：  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// リンクされた Excel ファイルを使用して OLE オブジェクトフレームを追加します。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **OLE オブジェクトフレームにアクセス** 

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順で簡単に検索またはアクセスできます： 

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションをロードします。 
2. インデックスを使用してスライドの参照を取得します。 
3. [OleObjectFrame] シェイプにアクセスします。例では、最初のスライドに 1 つだけシェイプがある事前に作成された PPTX を使用しました。次にそのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) に*cast*し、目的の OLE オブジェクトフレームにアクセスしました。 
4. OLE オブジェクトフレームにアクセスできたら、任意の操作を実行できます。 

以下の例では、スライドに埋め込まれた OLE オブジェクトフレーム（Excel チャートオブジェクト）とそのファイルデータにアクセスしています。  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // 埋め込まれたファイルデータを取得します。
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // 埋め込まれたファイルの拡張子を取得します。
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **リンクされた OLE オブジェクトフレームのプロパティにアクセス** 

Aspose.Slides を使用すると、リンクされた OLE オブジェクトフレームのプロパティにアクセスできます。  

以下の Java コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンクされたファイルへのパスを取得する方法を示しています：  
```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // OLE オブジェクトがリンクされているか確認します。
    if (oleFrame.isObjectLink()) {
        // リンクされたファイルのフルパスを出力します。
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // 存在する場合はリンクされたファイルの相対パスを出力します。
        // PPT プレゼンテーションのみが相対パスを含めることができます。
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```


## **OLE オブジェクトデータを変更** 

{{% alert color="primary" %}} 

このセクションでは、以下のコード例で [Aspose.Cells for Android via Java](/cells/androidjava/) を使用しています。  

{{% /alert %}} 

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順でオブジェクトにアクセスしデータを変更できます： 

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションをロードします。 
2. インデックスを使用してスライドの参照を取得します。 
3. OLE オブジェクトフレーム シェイプにアクセスします。例では、最初のスライドに 1 つだけシェイプがある事前に作成された PPTX を使用しました。次にそのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) に*cast*し、目的の OLE オブジェクトフレームにアクセスしました。 
4. OLE オブジェクトフレームにアクセスできたら、任意の操作を実行できます。 
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。 
6. 対象の `Worksheet` にアクセスし、データを修正します。 
7. 更新された `Workbook` をストリームに保存します。 
8. ストリームから OLE オブジェクトデータを変更します。 

以下の例では、スライドに埋め込まれた OLE オブジェクトフレーム（Excel チャートオブジェクト）にアクセスし、ファイルデータを修正してチャートデータを更新しています。  
```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLE オブジェクトのデータを Workbook オブジェクトとして読み取ります。
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // ワークブックのデータを変更します。
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // OLE フレームオブジェクトのデータを変更します。
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **スライドに他のファイルタイプを埋め込む** 

Excel チャートに加えて、Aspose.Slides for Android via Java を使用すると、スライドに他の種類のファイルを埋め込むことができます。たとえば、HTML、PDF、ZIP ファイルをオブジェクトとして挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、自動的に関連プログラムで開かれるか、開くプログラムの選択が促されます。  

以下の Java コードは、HTML と ZIP をスライドに埋め込む方法を示しています：  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **埋め込みオブジェクトのファイルタイプを設定** 

プレゼンテーションを扱う際、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされたものに置き換える必要がある場合があります。Aspose.Slides for Android via Java を使用すると、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレームのデータや拡張子を更新できます。  

以下の Java コードは、埋め込み OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています：  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **埋め込みオブジェクトのアイコン画像とタイトルを設定** 

OLE オブジェクトを埋め込むと、アイコン画像からなるプレビューが自動的に追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。プレビューに特定の画像とテキストを使用したい場合は、Aspose.Slides for Android via Java を使用してアイコン画像とタイトルを設定できます。  

以下の Java コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています：  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// プレゼンテーションのリソースに画像を追加します。
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **OLE オブジェクトフレームのサイズ変更と位置変更を防止** 

リンクされた OLE オブジェクトをプレゼンテーション スライドに追加した後、PowerPoint でプレゼンテーションを開くと、リンクの更新を求めるメッセージが表示されることがあります。「Update Links」 ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトからデータを更新しプレビューを再描画するため、OLE オブジェクトフレームのサイズや位置が変更されることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) インターフェイスの `setUpdateAutomatic` メソッドを `false` に設定します：  
```java
oleFrame.setUpdateAutomatic(false);
```


## **埋め込みファイルを抽出** 

Aspose.Slides for Android via Java を使用すると、スライドに OLE オブジェクトとして埋め込まれたファイルを次の手順で抽出できます： 

1. 抽出対象の OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。 
2. プレゼンテーション内のすべてのシェイプをループし、[OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe) シェイプにアクセスします。 
3. OLE オブジェクトフレームから埋め込みファイルのデータにアクセスし、ディスクに書き出します。 

以下の Java コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています：  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```


## **FAQ** 

**スライドを PDF/画像にエクスポートした際、OLE コンテンツは描画されますか？**  

スライド上に表示されているものが描画されます—アイコン/代替画像（プレビュー）です。 「ライブ」 な OLE コンテンツはレンダリング中に実行されません。必要に応じて、独自のプレビュー画像を設定し、エクスポートされた PDF で期待通りの外観になるようにしてください。  

**PowerPoint でユーザーが OLE オブジェクトを移動/編集できないようにロックするにはどうすればよいですか？**  

シェイプをロックします。Aspose.Slides は [shape-level locks](/slides/ja/androidjava/applying-protection-to-presentation/) を提供しています。これは暗号化ではありませんが、誤操作による編集や移動を実質的に防止します。  

**リンクされた Excel オブジェクトを開くと「ジャンプ」したりサイズが変わったりするのはなぜですか？**  

PowerPoint がリンクされた OLE のプレビューを再描画することがあります。安定した表示を得るために、[Working Solution for Worksheet Resizing](/slides/ja/androidjava/working-solution-for-worksheet-resizing/) の手順に従い、フレームを範囲に合わせるか、範囲を固定フレームにスケーリングし、適切な代替画像を設定してください。  

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**  

PPTX では「相対パス」情報は利用できず、フルパスのみが保存されます。相対パスは旧形式の PPT に存在します。可搬性を確保するため、信頼できる絶対パス/アクセス可能な URI もしくは埋め込みを使用することを推奨します。