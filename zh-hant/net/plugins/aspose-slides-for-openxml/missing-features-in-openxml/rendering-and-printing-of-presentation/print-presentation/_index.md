---
title: 列印簡報
type: docs
url: /zh-hant/net/print-the-presentation/
---
Aspose.Slides for .NET 為簡報提供四種重載的列印方法。這些方法具有彈性，足以將簡報列印到預設印表機或任何可用的印表機，並可自訂設定。您只需根據需求選擇適當的列印方法。

## **列印至預設印表機**
在 Aspose.Slides for .NET 中，將簡報列印至預設印表機相當簡單。依照以下步驟即可將簡報列印至預設印表機：

- 建立 Presentation 類別的實例以載入要列印的簡報
- 呼叫 Presentation 物件所提供的 Print 方法且不帶參數

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //載入簡報

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //呼叫列印方法將整個簡報列印至預設印表機

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //載入簡報

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //呼叫列印方法將整個簡報列印至指定的印表機

    asposePresentation.Print("LaserJet1100");
``` 
## **列印至指定印表機**
將簡報列印至特定印表機需要將印表機名稱作為參數傳遞給 Presentation 的 Print 方法。依照以下步驟即可將簡報列印至指定的印表機：

- 建立 Presentation 類別的實例以載入要列印的簡報
- 呼叫 Presentation 類別的 Print 方法，並將印表機名稱作為字串參數傳入

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //載入簡報

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //呼叫列印方法將整個簡報列印至指定的印表機

    asposePresentation.Print("LaserJet1100");

}
``` 
## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)