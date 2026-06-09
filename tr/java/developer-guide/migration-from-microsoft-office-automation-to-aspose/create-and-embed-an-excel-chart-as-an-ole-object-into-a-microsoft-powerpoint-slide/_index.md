---
title: VSTO ve Aspose.Slides for Java kullanarak Excel Grafiklerini OLE Nesneleri olarak Oluşturma ve Gömme
linktitle: Excel Grafiklerini OLE Nesneleri olarak Oluştur ve Göm
type: docs
weight: 60
url: /tr/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- grafik oluştur
- Excel grafiğini göm
- OLE nesnesi
- geçiş
- VSTO
- Office otomasyonu
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Microsoft Office otomasyonundan Aspose.Slides for Java'a geçiş yapın ve Excel grafiklerini OLE nesneleri olarak PowerPoint (PPT, PPTX) slaytlarına Java'da gömün."
---
{{% alert color="primary" %}} 

Grafikler, verilerinizin görsel temsilleridir ve sunum slaytlarında yaygın olarak kullanılır. Bu makale, [VSTO](/slides/tr/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) ve [Aspose.Slides for Java](/slides/tr/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) kullanarak bir Excel Grafiğini OLE Nesnesi olarak PowerPoint Slaytına programlı bir şekilde oluşturma ve gömme kodunu gösterecektir.

{{% /alert %}} 
## **Excel Grafiği Oluşturma ve Gömme**
Aşağıdaki iki kod örneği uzundur ve ayrıntılıdır çünkü açıklanan görev karmaşıktır. Bir Microsoft Excel çalışma kitabı oluşturur, bir grafik oluşturur ve ardından grafiği gömeceğiniz Microsoft PowerPoint sunumunu oluşturursunuz. OLE nesneleri, özgün belgeye bağlantılar içerir; bu nedenle gömülü dosyaya çift tıklayan bir kullanıcı dosyayı ve uygulamasını başlatır.
### **VSTO Örneği**
VSTO kullanarak, aşağıdaki adımlar uygulanır:

1. Microsoft Excel ApplicationClass nesnesinin bir örneğini oluşturun.
1. Bir sayfası olan yeni bir çalışma kitabı oluşturun.
1. Sayfaya bir grafik ekleyin.
1. Çalışma kitabını kaydedin.
1. Grafik verilerini içeren çalışma sayfasını içeren Excel çalışma kitabını açın.
1. Sayfa için ChartObjects koleksiyonunu alın.
1. Kopyalanacak grafiği alın.
1. Microsoft PowerPoint sunumu oluşturun.
1. Sunuma boş bir slayt ekleyin.
1. Grafiği Excel çalışma sayfasından panoya kopyalayın.
1. Grafiği PowerPoint sunumuna yapıştırın.
1. Grafiği slayt üzerinde konumlandırın.
1. Sunumu kaydedin.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Aspose.Slides for Java Örneği**
Aspose.Slides for .NET kullanarak, aşağıdaki adımlar uygulanır:

1. Aspose.Cells for Java kullanarak bir çalışma kitabı oluşturun.
1. Microsoft Excel grafiği oluşturun.
1. Excel Grafiğinin OLE boyutunu ayarlayın.
1. Grafiğin bir görüntüsünü alın.
1. Aspose.Slides for Java kullanarak Excel grafiğini PPTX sunumunda OLE Nesnesi olarak gömün.
1. Nesne değişikliği sorununu gidermek için, 3. adımda elde edilen görüntüyü nesnenin değiştirildi görüntüsüyle değiştirin.
1. Çıktı sunumunu PPTX formatında diske yazın.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}