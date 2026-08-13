---
title: Lisanslama
type: docs
weight: 50
url: /tr/jasperreports/licensing/
---
{{% alert color="info" %}} 

Aspose.Slides for JasperReports, [download page](https://downloads.aspose.com/slides/tr/jasperreport) üzerinden sınırsız süreli ücretsiz değerlendirme olarak mevcuttur. Ürünün değerlendirme ve lisanslı sürümleri aynı indirme bağlantısından temin edilebilir.

Değerlendirmeden memnun kaldığınızda, [buy a license](https://purchase.aspose.com/buy). Abonelik şartlarını anladığınızdan ve kabul ettiğinizden emin olun.

Sipariş ödendikten sonra lisans sipariş sayfasından indirilebilir. Lisans, istemci adı, satın alınan ürün ve lisans tipi gibi bilgileri içeren, düz metin, dijital imzalı bir XML dosyasıdır. Lisans dosyasının içeriğini hiçbir şekilde değiştirmeyin: bu, lisansı geçersiz kılar.

Lisansı bilgisayarınıza indirin ve uygun klasöre kopyalayın (örneğin uygulama klasörünüz veya **JasperReports\lib**).
{{% /alert %}}

## **Değerlendirme Sürümü Kısıtlaması**
Değerlendirme sürümü Aspose.Slides (lisans belirtilmemiş) tam ürün işlevselliği sağlar, ancak sunumlarınızı kaydettiğinizde her slaytın ortasına aşağıdaki şekilde gösterilen bir değerlendirme filigranı ekler:

![todo:image_alt_text](evaluation_watermark.png) 

## **Lisans Uygulama**
Lisans uygulamanın birkaç yolu vardır; bu, JasperReports üzerinde mi yoksa JasperServer üzerinde mi çalıştığınıza bağlıdır.

### **JasperReports için Lisans Uygulama**
Aspose.Slides for Java'ye benzer şekilde doğrudan setLicense yöntemi çağrısını kullanın.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Lisans dosyasını içeren bir akış nesnesi oluştur
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //License sınıfını örnekle
    License license = new License();
	
    //Akış nesnesi üzerinden lisansı ayarla
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Ya da, kod içinde dışa aktarım parametresini ayarlayın.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **JasperServer'da Lisans Uygulama**
applicationContext.xml dosyasında dışa aktarım parametresini ayarlayın.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```