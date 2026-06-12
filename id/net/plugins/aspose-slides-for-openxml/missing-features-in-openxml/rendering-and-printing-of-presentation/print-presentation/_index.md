---
title: Cetak Presentasi
type: docs
url: /id/net/print-the-presentation/
---
Aspose.Slides for .NET menyediakan empat overload metode untuk mencetak presentasi. Metode ini cukup fleksibel untuk mencetak presentasi ke printer default atau ke printer mana pun yang tersedia dengan pengaturan yang disesuaikan. Anda hanya perlu memilih metode cetak yang tepat sesuai kebutuhan.
## **Cetak ke Printer Default**
Mencetak presentasi ke printer default cukup sederhana di Aspose.Slides for .NET. Lakukan langkah-langkah berikut untuk mencetak presentasi ke printer default:

- Buat instance kelas Presentation untuk memuat presentasi yang akan dicetak
- Panggil metode Print tanpa parameter seperti yang disediakan oleh objek Presentation

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Muat presentasi

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Panggil metode print untuk mencetak seluruh presentasi ke printer default

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Muat presentasi

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Panggil metode print untuk mencetak seluruh presentasi ke printer yang diinginkan

    asposePresentation.Print("LaserJet1100");
``` 
## **Cetak ke Printer Tertentu**
Mencetak presentasi ke printer tertentu memerlukan nama printer sebagai parameter ke metode Print pada Presentation. Lakukan langkah-langkah berikut untuk mencetak presentasi ke printer yang diinginkan:

- Buat instance kelas Presentation untuk memuat presentasi yang akan dicetak
- Panggil metode Print dari kelas Presentation dengan nama printer sebagai parameter string ke metode Print

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Muat presentasi

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Panggil metode print untuk mencetak seluruh presentasi ke printer yang diinginkan

    asposePresentation.Print("LaserJet1100");

}

``` 
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)