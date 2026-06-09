---
title: Sunumu Yazdır
type: docs
url: /tr/net/print-the-presentation/
---
Aspose.Slides for .NET, sunumların yazdırılması için dört aşırı yüklü yöntem sağlar. Bu yöntemler, sunumu varsayılan yazıcıya veya özelleştirilmiş ayarlarla mevcut herhangi bir yazıcıya yazdıracak kadar esnektir. Sadece gereksinime göre uygun yazdırma yöntemini seçmeniz yeterlidir.
## **Varsayılan Yazıcıya Yazdır**
Aspose.Slides for .NET'te sunumu varsayılan yazıcıya yazdırmak oldukça basittir. Sunumu varsayılan yazıcıya yazdırmak için aşağıdaki adımları izleyin:

- Yazdırılacak bir sunumu yüklemek için Presentation sınıfının bir örneğini oluşturun
- Presentation nesnesi tarafından sunulan Print yöntemini parametresiz olarak çağırın

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Sunumu yükle

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Yazdırma yöntemini çağırarak tüm sunumu varsayılan yazıcıya yazdır

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Sunumu yükle

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Yazdırma yöntemini çağırarak tüm sunumu istenen yazıcıya yazdır

    asposePresentation.Print("LaserJet1100");


``` 
## **Belirli Bir Yazıcıya Yazdır**
Sunumu belirli bir yazıcıya yazdırmak, Print yöntemine yazıcı adının parametre olarak verilmesini gerektirir. İstenilen yazıcıya sunumu yazdırmak için aşağıdaki adımları izleyin:

- Yazdırılacak bir sunumu yüklemek için Presentation sınıfının bir örneğini oluşturun
- Print yöntemine yazıcı adını string parametresi olarak vererek Presentation sınıfının Print yöntemini çağırın

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Sunumu yükle

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Yazdırma yöntemini çağırarak tüm sunumu istenen yazıcıya yazdır

    asposePresentation.Print("LaserJet1100");

}

``` 
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)