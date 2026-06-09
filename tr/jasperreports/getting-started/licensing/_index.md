---
title: Lisanslama
type: docs
weight: 50
url: /tr/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides for JasperReports, [download page](https://downloads.aspose.com/slides/tr/jasperreport) adresinden sınırsız süreli ücretsiz bir değerlendirme olarak mevcuttur. Ürünün değerlendirme ve lisanslı sürümleri aynı indirme dosyasını kullanır.

Değerlendirmeden memnun kaldığınızda, [bir lisans satın al](https://purchase.aspose.com/buy). Abonelik şartlarını anladığınızdan ve kabul ettiğinizden emin olun.

Sipariş ödemesinden sonra lisans, sipariş sayfasından indirilebilir. Lisans, istemci adı, satın alınan ürün ve lisans türü gibi bilgileri içeren düz metin, dijital imzalı bir XML dosyasıdır. Lisans dosyasının içeriğini hiçbir şekilde değiştirmeyin: değiştirmek lisansı geçersiz kılar.

Lisansı bilgisayarınıza indirip uygun klasöre kopyalayın (örneğin uygulama klasörünüz veya **JasperReports\lib**).

## **Değerlendirme Sürümü Sınırlaması**
Lisans belirtilmemiş Aspose.Slides değerlendirme sürümü tam ürün işlevselliğini sağlar, ancak (sunumlarınızı kaydettiğinizde) aşağıdaki figürde gösterildiği gibi her slaydın ortasına bir değerlendirme filigranı ekler:

![todo:image_alt_text](evaluation_watermark.png) 

## **Lisans Uygulama**
JasperReports ya da JasperServer üzerinde çalışmanıza bağlı olarak lisans uygulamanın birkaç farklı yolu vardır.

### **JasperReports için Lisans Uygulama**
Aspose.Slides for Java'ye benzer şekilde doğrudan setLicense yöntemi çağrısı kullanın.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Lisans dosyasını içeren bir akış nesnesi oluşturun
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //License sınıfını örnekleyin
    License license = new License();
	
    //Lisansı akış nesnesi aracılığıyla ayarlayın
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Veya, kod içinde dışa aktarıcı parametresini ayarlayın.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **JasperServer'da Lisans Uygulama**
applicationContext.xml içinde dışa aktarıcı parametresini ayarlayın.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```