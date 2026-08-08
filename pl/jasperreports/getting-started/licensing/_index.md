---
title: Licencjonowanie
type: docs
weight: 50
url: /pl/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides for JasperReports jest dostępny jako nieograniczona w czasie darmowa wersja ewaluacyjna ze [strony pobierania](https://downloads.aspose.com/slides/pl/jasperreport). Wersja ewaluacyjna i licencjonowana produktu są dostępne w tym samym pliku do pobrania.

Gdy ocena spełni Twoje oczekiwania, [kup licencję](https://purchase.aspose.com/buy). Upewnij się, że rozumiesz i akceptujesz warunki subskrypcji.

Licencja jest dostępna do pobrania ze strony zamówienia po opłaceniu zamówienia. Licencja jest plikiem XML w formacie czystego tekstu, cyfrowo podpisanym i zawiera informacje takie jak nazwa klienta, zakupiony produkt oraz typ licencji. Nie modyfikuj w żaden sposób zawartości pliku licencji: spowoduje to unieważnienie licencji.

Pobierz licencję na swój komputer i skopiuj ją do odpowiedniego folderu (np. folderu aplikacji lub **JasperReports\lib**).
{{% /alert %}}

## **Ograniczenia wersji ewaluacyjnej**
Wersja ewaluacyjna Aspose.Slides (bez określonej licencji) zapewnia pełną funkcjonalność produktu, ale (przy zapisywaniu prezentacji) wstawia znak wodny ewaluacji w centrum każdego slajdu, jak pokazano na rysunku poniżej:

![todo:image_alt_text](evaluation_watermark.png) 

## **Stosowanie licencji**
Istnieje kilka sposobów zastosowania licencji, w zależności od tego, czy pracujesz z JasperReports, czy JasperServer.

### **Stosowanie licencji dla JasperReports**
Użyj bezpośredniego wywołania metody setLicense podobnie jak w Aspose.Slides dla Javy.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Utwórz obiekt strumienia zawierający plik licencji
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Utwórz instancję klasy License
    License license = new License();
	
    //Ustaw licencję przy użyciu obiektu strumienia
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Lub ustaw parametr eksportera w kodzie.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Stosowanie licencji w JasperServer**
Ustaw parametr eksportera w pliku applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```