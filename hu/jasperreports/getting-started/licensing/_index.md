---
title: Licencelés
type: docs
weight: 50
url: /hu/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Az Aspose.Slides for JasperReports ingyenes, időkorlát nélküli kiértékelésként érhető el a [letöltési oldalon](https://downloads.aspose.com/slides/hu/jasperreport). A termék kiértékelési és licencelt verziói ugyanarról a letöltésről származnak.

Ha elégedett vagy a kiértékeléssel, [vásárolj licencet](https://purchase.aspose.com/buy). Győződj meg arról, hogy érted és elfogadod az előfizetési feltételeket.

A licenc a rendelési oldalon tölthető le, miután a rendelés ki lett fizetve. A licenc egy egyszerű szöveges, digitálisan aláírt XML fájl, amely információkat tartalmaz, például az ügyfél nevét, a megvásárolt terméket és a licenc típusát. Ne módosítsd semmilyen módon a licencfájl tartalmát: ez érvényteleníti a licencet.

Töltsd le a licencet a számítógépedre, és másold a megfelelő mappába (például az alkalmazás mappájába vagy a **JasperReports\lib** könyvtárba).
{{% /alert %}}

## **Értékelő Verzió Korlátozása**
Az Aspose.Slides értékelő verziója (licenc megadása nélkül) a termék teljes funkcionalitását biztosítja, de (amikor mented a prezentációkat) egy értékelési vízjelet helyez a minden dia közepére, ahogy az alábbi ábrán látható:

![todo:image_alt_text](evaluation_watermark.png) 

## **Licenc Alkalmazása**
Számos módja van a licenc alkalmazásának, attól függően, hogy a JasperReports vagy a JasperServer környezetben dolgozol.

### **Licenc Alkalmazása JasperReports-hez**
Használj közvetlen setLicense metódushívást, hasonlóan az Aspose.Slides for Java-hoz.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Hozzon létre egy adatfolyam objektumot, amely a licencfájlt tartalmazza
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Példányosítsa a License osztályt
    License license = new License();
	
    //Állítsa be a licencet az adatfolyam objektumon keresztül
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Vagy állítsd be az exporter paramétert a kódban.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Licenc Alkalmazása JasperServer-en**
Állítsd be az exporter paramétert az applicationContext.xml-ben.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```