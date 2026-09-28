---
title: Lisanslama
type: docs
weight: 50
url: /tr/jasperreports/licensing/
description: "Aspose.Slides for JasperReports'in değerlendirme sürümünün dışa aktarılan dosyalara eklediği şeyleri öğrenin ve JasperReports ile JasperReports Server'da bir lisansı nasıl uygulayacağınızı keşfedin."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for JasperReports, ücretsiz ve süresiz bir değerlendirme sürümü olarak [download page](https://releases.aspose.com/slides/jasperreport/) adresinden indirilebilir. Ürünün değerlendirme ve lisanslı sürümleri aynı indirme dosyasını kullanır.

Değerlendirmeden memnun kaldığınızda, [buy a license](https://purchase.aspose.com/pricing/slides/jasperreports/) satın alabilirsiniz. Abonelik koşullarını anladığınızdan ve kabul ettiğinizden emin olun.

Lisans, sipariş sayfasından ödeme yapıldıktan sonra indirilebilir. Lisans, istemci adı, satın alınan ürün ve lisans türü gibi bilgileri içeren, açık metin, dijital olarak imzalanmış bir XML dosyasıdır. Lisans dosyasının içeriğini hiçbir şekilde değiştirmeyin: değiştirmek lisansı geçersiz kılar.

Lisansı bilgisayarınıza indirin ve uygun klasöre kopyalayın (örneğin uygulama klasörünüz veya **JasperReports\lib**).
{{% /alert %}}

## **Değerlendirme Sürümü Sınırı**
Aspose.Slides for JasperReports'in değerlendirme sürümü (lisans belirtilmemiş) raporun her sayfasını dışa aktarır, ancak her slaytın veya sayfanın ortasına, dört çıktı formatının (PPT, PPTX, PDF ve HTML) tamamında bir değerlendirme filigranı ekler; aşağıdaki şekilde gösterilmiştir. Ayrıntılar için [Evaluate Aspose.Slides](/slides/tr/jasperreports/evaluate-aspose-slides/) sayfasına bakın.

![Dışa aktarılan bir slayın ortasındaki değerlendirme filigranı](evaluation_watermark.png)

## **Lisans Uygulama**
Bir lisansı uygulamanın birkaç yolu vardır; bu, JasperReports üzerinde mi yoksa JasperServer üzerinde mi çalıştığınıza bağlıdır.

### **JasperReports için Lisans Uygulama**
`License` sınıfının `setLicense` metodunu, lisans dosyasını okuyan bir akış ile çağırın; bu, Aspose.Slides for Java'daki gibi:

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // Lisans dosyasını içeren bir akış nesnesi oluşturun.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // License sınıfının bir örneğini oluştur.
            License license = new License();

            // Lisansı akış nesnesi aracılığıyla ayarla.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

Alternatif olarak, lisans dosyasının yolunu `ASExporterParameters.PPT_LICENSE` parametresinde dışa aktarıcıya iletebilirsiniz. Bu parçacıkta `jasperPrint` doldurulmuş bir rapordur; [Your first export](/slides/tr/jasperreports/#your-first-export) için olduğu gibi:

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **JasperServer'da Lisans Uygulama**
**applicationContext.xml** içindeki `pptExportParameters` bean'inin `licenseFile` özelliğini, lisans dosyasının yoluna ayarlayın; bu, [Integration with JasperServer](/slides/tr/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license) örneğinde gösterildiği gibidir.