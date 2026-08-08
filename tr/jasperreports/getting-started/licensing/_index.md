---
title: Lisanslama
type: docs
weight: 50
url: /tr/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides for JasperReports, sınırsız ücretsiz deneme sürümü olarak [indir sayfasından](https://downloads.aspose.com/slides/tr/jasperreport) temin edilebilir. Ürünün deneme ve lisanslı sürümleri aynı indirme bağlantısından sağlanır.

Deneme sürümünden memnun kalınca [bir lisans satın alın](https://purchase.aspose.com/buy). Abonelik koşullarını anladığınızdan ve kabul ettiğinizden emin olun.

Sipariş ödendikten sonra lisans, sipariş sayfasından indirilebilir. Lisans, müşteri adı, satın alınan ürün ve lisans türü gibi bilgileri içeren açık metin, dijital imzalı bir XML dosyasıdır. Lisans dosyasının içeriğini hiçbir şekilde değiştirmeyin: değiştirmek lisansı geçersiz kılar.

Lisansı bilgisayarınıza indirin ve uygun klasöre kopyalayın (örneğin uygulama klasörünüz ya da **JasperReports\lib**).
{{% /alert %}}

## **Değerlendirme Sürümü Sınırlaması**
Lisans belirtilmemiş Aspose.Slides değerlendirme sürümü tam ürün işlevselliği sağlar, ancak (sunumlarınızı kaydettiğinizde) aşağıdaki şekilde gösterildiği gibi her slaytın ortasına bir değerlendirme filigranı ekler:

![todo:image_alt_text](evaluation_watermark.png) 

## **Lisans Uygulama**
Lisansı uygulamanın birkaç yolu vardır; JasperReports veya JasperServer üzerinde çalışıp çalışmadığınıza bağlı olarak.

### **JasperReports için Lisans Uygulama**
Aspose.Slides for Java'ye benzer şekilde doğrudan bir setLicense yöntemi çağrısı kullanın.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Lisans dosyasını içeren bir akış nesnesi oluşturun
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //License sınıfının bir örneğini oluşturun
    License license = new License();
	
    //Lisansı akış nesnesi üzerinden ayarlayın
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Ya da, kod içinde exporter parametresini ayarlayın.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **JasperServer'da Lisans Uygulama**
exporter parametresini applicationContext.xml içinde ayarlayın.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```