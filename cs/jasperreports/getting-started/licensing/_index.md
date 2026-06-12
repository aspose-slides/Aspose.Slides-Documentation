---
title: Licencování
type: docs
weight: 50
url: /cs/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides pro JasperReports je k dispozici jako neomezené bezplatné hodnocení na [stránka ke stažení](https://downloads.aspose.com/slides/cs/jasperreport). Evaluační a licencovaná verze produktu jsou ke stažení ze stejného místa.

Jakmile budete s hodnocením spokojeni, [kupte licenci](https://purchase.aspose.com/buy). Ujistěte se, že rozumíte a souhlasíte s podmínkami předplatného.

Licence je k dispozici ke stažení na stránce objednávky poté, co byla objednávka zaplacena. Licence je čistý textový, digitálně podepsaný soubor XML, který obsahuje informace jako název klienta, zakoupený produkt a typ licence. Neměňte obsah souboru licence žádným způsobem: takové úpravy licenci neplatní.

Stáhněte licenci do počítače a zkopírujte ji do příslušné složky (například do složky aplikace nebo **JasperReports\lib**).

## **Omezení evaluační verze**
Evaluační verze Aspose.Slides (bez specifikované licence) poskytuje plnou funkčnost produktu, ale (při ukládání prezentací) vkládá evaluační vodoznak do středu každého snímku, jak je uvedeno na obrázku níže:

![todo:image_alt_text](evaluation_watermark.png) 

## **Použití licence**
Existuje několik způsobů, jak licenci použít, v závislosti na tom, zda pracujete s JasperReports nebo JasperServer.

### **Použití licence pro JasperReports**
Použijte přímé volání metody setLicense podobně jako v Aspose.Slides pro Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Vytvořte objekt proudu obsahující soubor licence
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Vytvořte instanci třídy License
    License license = new License();
	
    //Nastavte licenci pomocí objektu proudu
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