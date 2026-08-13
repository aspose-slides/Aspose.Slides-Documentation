---
title: VSTO ve Aspose.Slides for Java Kullanarak Grafik Oluşturma
linktitle: Grafik Oluştur
type: docs
weight: 70
url: /tr/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- grafik oluştur
- geçiş
- VSTO
- Office otomasyonu
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Java’da PowerPoint grafik oluşturmayı nasıl otomatikleştireceğinizi öğrenin. Bu adım adım rehber, Aspose.Slides for Java’ın Microsoft.Office.Interop’a göre daha hızlı ve daha güçlü bir alternatif olduğunu gösterir."
---
{{% alert color="info" %}} 

Grafikler, sunumlarda yaygın olarak kullanılan verilerin görsel temsilleridir. Bu makale, [VSTO](/slides/tr/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) ve [Aspose.Slides for Java](/slides/tr/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) kullanarak Microsoft PowerPoint’te programlı olarak bir grafik oluşturma kodunu gösterir.

{{% /alert %}} 
## **Grafik Oluşturma**
Aşağıdaki kod örnekleri, VSTO kullanarak basit bir 3D kümelenmiş sütun grafiği ekleme sürecini açıklar. Bir sunum örneği oluşturur, ona varsayılan bir grafik eklersiniz. Ardından, grafik verilerine erişmek ve bu verileri değiştirmek, ayrıca grafik özelliklerini ayarlamak için Microsoft Excel çalışma kitabını kullanırsınız. Son olarak, sunumu kaydedersiniz.
### **VSTO Örneği**
VSTO kullanarak aşağıdaki adımlar uygulanır:

1. Microsoft PowerPoint sunumunun bir örneğini oluşturun.
1. Sunuma boş bir slayt ekleyin.
1. Bir **3D kümelenmiş sütun** grafiği ekleyin ve ona erişin.
1. Yeni bir Microsoft Excel Workbook örneği oluşturun ve grafik verilerini yükleyin.
1. Microsoft Excel Workbook instancefromworkbook kullanarak grafik veri çalışma sayfasına erişin.
1. Çalışma sayfasındaki grafik aralığını ayarlayın ve grafikten 2 ve 3 numaralı serileri kaldırın.
1. Grafik veri çalışma sayfasında grafik kategori verilerini değiştirin.
1. Grafik veri çalışma sayfasında grafik serisi 1 verilerini değiştirin.
1. Şimdi, grafik başlığına erişin ve yazı tipi ile ilgili özellikleri ayarlayın.
1. Grafik değer eksenine erişin ve büyük birim, küçük birimler, maksimum değer ve minimum değerleri ayarlayın.
1. Grafik derinlik ya da seri eksenine erişin ve bu örnekte yalnızca bir serinin kullanıldığı için onu kaldırın.
1. Şimdi, grafik dönüş açılarını X ve Y yönünde ayarlayın.
1. Sunumu kaydedin.
1. Microsoft Excel ve PowerPoint örneklerini kapatın.

**VSTO ile oluşturulan çıktı sunumu** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides for Java Örneği**
Aspose.Slides for Java kullanarak aşağıdaki adımlar uygulanır:

1. Microsoft PowerPoint sunumunun bir örneğini oluşturun.
1. Sunuma boş bir slayt ekleyin.
1. Bir **3D kümelenmiş sütun** grafiği ekleyin ve ona erişin.
1. Microsoft Excel Workbook instancefromworkbook kullanarak grafik veri çalışma sayfasına erişin.
1. Kullanılmayan 2 ve 3 numaralı serileri kaldırın.
1. Grafik kategorilerine erişin ve etiketleri değiştirin.
1. Seri 1'e erişin ve seri değerlerini değiştirin.
1. Şimdi, grafik başlığına erişin ve yazı tipi özelliklerini ayarlayın.
1. Grafik değer eksenine erişin ve büyük birim, küçük birimler, maksimum değer ve minimum değerleri ayarlayın.
1. Şimdi, grafik dönüş açılarını X ve Y yönünde ayarlayın.
1. Sunumu PPTX formatında kaydedin.

**Aspose.Slides ile oluşturulan çıktı sunumu** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **SSS**

### Aspose.Slides ile pasta, çizgi veya çubuk grafikleri gibi diğer grafik türlerini oluşturabilir miyim?
Evet. Aspose.Slides, pasta grafikler, çizgi grafikler, çubuk grafikler, dağılım grafikleri, balon grafikler ve daha fazlası dahil olmak üzere geniş bir [grafik türleri](/slides/tr/java/create-chart/) yelpazesini destekler. Bir grafik eklerken istediğiniz grafik türünü [ChartType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/) sınıfını kullanarak belirtebilirsiniz.

### Grafiğe özel stiller veya temalar uygulayabilir miyim?
Evet. Renkler, yazı tipleri, doldurmalar, kenarlıklar, ızgara çizgileri ve düzen gibi grafik görünümünü tamamen özelleştirebilirsiniz. Ancak, PowerPoint’te görülen Office temalarını tam olarak uygulamak, bireysel stilleri manuel olarak ayarlamayı gerektirir.

### Grafiği slayttan ayrı olarak bir görüntüye dışa aktarabilir miyim?
Evet, Aspose.Slides, grafik [şekli](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/) üzerindeki `getImage` yöntemi kullanılarak herhangi bir şekli—grafikleri de dahil—ayrı bir görüntü (ör. PNG, JPEG) olarak dışa aktarmanıza olanak tanır.