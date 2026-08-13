---
title: Licencování
type: docs
weight: 50
url: /cs/jasperreports/licensing/
---
{{% alert color="info" %}} 

Aspose.Slides pro JasperReports je k dispozici jako neomezená bezplatná zkušební verze ke stažení na [stahovací stránku](https://downloads.aspose.com/slides/cs/jasperreport). Stáhnout lze jak zkušební, tak licencovanou verzi produktu.

Když budete se zkušební verzí spokojeni, [zakoupit licenci](https://purchase.aspose.com/buy). Ujistěte se, že rozumíte a souhlasíte s podmínkami předplatného.

Licence je k dispozici ke stažení na stránce objednávky po zaplacení objednávky. Licence je čitelný text, digitálně podepsaný soubor XML, který obsahuje informace, jako je jméno klienta, zakoupený produkt a typ licence. Nezasahujte žádným způsobem do obsahu souboru licence: taková úprava licenci neplatnou.

Stáhněte licenci do počítače a zkopírujte ji do příslušné složky (například do složky aplikace nebo **JasperReports\lib**).
{{% /alert %}}

## **Omezení zkušební verze**
Zkušební verze Aspose.Slides (bez uvedené licence) poskytuje plnou funkčnost produktu, ale při ukládání prezentací vkládá evaluační vodoznak doprostřed každého snímku, jak je vidět na obrázku níže:

![todo:image_alt_text](evaluation_watermark.png) 

## **Použití licence**
Existuje několik způsobů, jak použít licenci, v závislosti na tom, zda pracujete s JasperReports nebo JasperServer.

### **Použití licence pro JasperReports**
Použijte přímé volání metody setLicense podobně jako v Aspose.Slides pro Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Vytvořte objekt proudu obsahující licenční soubor
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Instancujte třídu License
    License license = new License();
	
    //Nastavte licenci prostřednictvím objektu proudu
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Nebo nastavte parametr exportéru v kódu.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Použití licence na JasperServer**
Nastavte parametr exportéru v souboru applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```