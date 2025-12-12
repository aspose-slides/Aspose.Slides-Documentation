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
- OLE を埋め込む
- オブジェクトを追加
- オブジェクトを埋め込む
- ファイルを追加
- ファイルを埋め込む
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

OLE（Object Linking & Embedding）は、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みによって別のアプリケーションに配置できる Microsoft の技術です。

{{% /alert %}} 

MS Excelで作成されたチャートを考えてみてください。そのチャートが PowerPoint のスライド内に配置されます。その Excel チャートは OLE オブジェクトとみなされます。

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、チャートは関連付けられたアプリケーション（Excel）で開かれるか、オブジェクトの開閉や編集に使用するアプリケーションの選択を求められます。
- OLE オブジェクトは実際の内容（例えばチャートの内容）を表示することがあります。この場合、チャートは PowerPoint 内でアクティブ化され、チャートインターフェイスがロードされ、PowerPoint 内でチャートのデータを変更できます。

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) を使用すると、OLE オブジェクトをスライドに OLE オブジェクト フレーム（[OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)）として挿入できます。

## **スライドに OLE オブジェクト フレームを追加する**

Microsoft Excel で既にチャートを作成しており、Aspose.Slides for Android via Java を使用して OLE オブジェクト フレームとしてスライドに埋め込みたい場合は、次の手順で実行できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. Excel ファイルをバイト配列として読み取ります。
1. バイト配列と OLE オブジェクトに関するその他の情報を含む [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) をスライドに追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、Excel ファイルからチャートを取得し、Aspose.Slides for Android via Java を使用して OLE オブジェクト フレームとしてスライドに追加しています。  
**Note**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) コンストラクタは第2パラメータとして埋め込み可能オブジェクトの拡張子を受け取ります。この拡張子により PowerPoint はファイルタイプを正しく解釈し、適切なアプリケーションで OLE オブジェクトを開くことができます。  
```java
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE オブジェクトのデータを準備します。
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// スライドに OLE オブジェクト フレームを追加します。
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **リンクされた OLE オブジェクト フレームを追加する**

Aspose.Slides for Android via Java を使用すると、データを埋め込まずにファイルへのリンクだけで [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) を追加できます。

この Java コードは、リンクされた Excel ファイルを持つ [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) をスライドに追加する方法を示しています。  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// リンクされた Excel ファイルで OLE オブジェクト フレームを追加します。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **OLE オブジェクト フレームにアクセスする**

スライドに OLE オブジェクトが既に埋め込まれている場合、以下の手順で簡単に見つけたりアクセスしたりできます。

1. 埋め込まれた OLE オブジェクトを含むプレゼンテーションを、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成してロードします。
2. インデックスを使用してスライドの参照を取得します。
3. [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) シェイプにアクセスします。  
   本例では、1枚目のスライドに1つだけシェイプがある事前に作成した PPTX を使用しています。そのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) と *cast* し、目的の OLE オブジェクト フレームとして取得しました。
4. OLE オブジェクト フレームにアクセスできたら、任意の操作を実行できます。

以下の例では、スライドに埋め込まれた Excel チャート オブジェクト（OLE オブジェクト フレーム）とそのファイルデータにアクセスしています。  
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


### **リンクされた OLE オブジェクト フレームのプロパティにアクセスする**

Aspose.Slides を使用すると、リンクされた OLE オブジェクト フレームのプロパティにアクセスできます。

この Java コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンクされたファイルへのパスを取得する方法を示しています。  
```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // OLE オブジェクトがリンクされているか確認します。
    if (oleFrame.isObjectLink()) {
        // リンクされたファイルへの完全なパスを出力します。
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // 存在する場合、リンクされたファイルへの相対パスを出力します。
        // 相対パスを含められるのは PPT プレゼンテーションだけです。
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```


## **OLE オブジェクト データを変更する**

{{% alert color="primary" %}} 

このセクションでは、以下のコード例で [Aspose.Cells for Android via Java](/cells/androidjava/) を使用しています。

{{% /alert %}}

スライドに OLE オブジェクトが既に埋め込まれている場合、以下の手順でオブジェクトにアクセスしデータを変更できます。

1. 埋め込まれた OLE オブジェクトを含むプレゼンテーションを、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成してロードします。
2. インデックスを使用してスライドの参照を取得します。 
3. OLE オブジェクト フレーム シェイプにアクセスします。  
   本例では、1枚目のスライドに1つだけシェイプがある事前に作成した PPTX を使用しています。そのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) と *cast* し、目的の OLE オブジェクト フレームとして取得しました。
4. OLE オブジェクト フレームにアクセスできたら、任意の操作を実行できます。
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。
6. 対象の `Worksheet` にアクセスし、データを修正します。
7. 更新した `Workbook` をストリームに保存します。
8. ストリームから OLE オブジェクト データを変更します。

以下の例では、スライドに埋め込まれた Excel チャート オブジェクト（OLE オブジェクト フレーム）にアクセスし、ファイルデータを変更してチャート データを更新しています。  
```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLE オブジェクト データを Workbook オブジェクトとして読み取ります。
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // ワークブック データを変更します。
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // OLE フレーム オブジェクト データを変更します。
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **スライドに他のファイルタイプを埋め込む**

Excel チャート以外にも、Aspose.Slides for Android via Java を使用すると、HTML、PDF、ZIP などのファイルをオブジェクトとしてスライドに埋め込むことができます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連プログラムで自動的に開くか、開くプログラムの選択を求められます。

この Java コードは、HTML と ZIP をスライドに埋め込む方法を示しています。  
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


## **埋め込みオブジェクトのファイルタイプを設定する**

プレゼンテーション作成時に、古い OLE オブジェクトを新しいものに置き換えたり、未対応の OLE オブジェクトを対応可能なものに置き換えたりする必要がある場合があります。Aspose.Slides for Android via Java を使用すると、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレーム データや拡張子を更新できます。

この Java コードは、埋め込み OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています。  
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


## **埋め込みオブジェクトのアイコン画像とタイトルを設定する**

OLE オブジェクトを埋め込むと、アイコン画像で構成されたプレビューが自動的に追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビュー要素として使用したい場合、Aspose.Slides for Android via Java を使用してアイコン画像とタイトルを設定できます。

この Java コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています。  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// プレゼンテーションリソースに画像を追加します。
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// OLE プレビュー用にタイトルと画像を設定します。
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **OLE オブジェクト フレームのサイズ変更や位置変更を防止する**

リンクされた OLE オブジェクトをプレゼンテーション スライドに追加した後、PowerPoint でプレゼンテーションを開くと「リンクの更新」を求めるメッセージが表示されることがあります。「リンクの更新」ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトのデータを更新しプレビューを再描画するため、OLE オブジェクト フレームのサイズや位置が変更されることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) インターフェイスの `setUpdateAutomatic` メソッドを `false` に設定します。  
```java
oleFrame.setUpdateAutomatic(false);
```


## **埋め込みファイルを抽出する**

Aspose.Slides for Android via Java を使用すると、スライドに OLE オブジェクトとして埋め込まれたファイルを以下の手順で抽出できます。

1. 抽出したい OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのシェイプをループし、[OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe) シェイプにアクセスします。
3. OLE オブジェクト フレームから埋め込みファイルのデータにアクセスし、ディスクに書き出します。

この Java コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています。  
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

**Will the OLE content be rendered when exporting slides to PDF/images?**

スライド上に表示されているものがレンダリングされます（アイコン/代替画像（プレビュー））。「ライブ」な OLE コンテンツはレンダリング時に実行されません。必要に応じて、独自のプレビュー画像を設定し、エクスポートされた PDF で期待通りの外観になるようにしてください。

**How can I lock an OLE object on a slide so users cannot move/edit it in PowerPoint?**

シェイプをロックします。Aspose.Slides は [シェイプレベルのロック](/slides/ja/androidjava/applying-protection-to-presentation/) を提供しています。これは暗号化ではありませんが、誤操作による編集や移動を実質的に防止します。

**Why does a linked Excel object "jump" or change size when I open the presentation?**

PowerPoint がリンクされた OLE のプレビューを再描画することがあります。安定した表示にするには、[Worksheet Resizing の実装例](/slides/ja/androidjava/working-solution-for-worksheet-resizing/) に従い、フレームを範囲に合わせるか、範囲を固定フレームにスケーリングし、適切な代替画像を設定してください。

**Will relative paths for linked OLE objects be preserved in the PPTX format?**

PPTX では「相対パス」情報は保存されず、フルパスのみが保持されます。相対パスは古い PPT 形式でのみ利用可能です。可搬性を考慮する場合は、信頼できる絶対パス／アクセス可能な URI を使用するか、埋め込みを選択してください。