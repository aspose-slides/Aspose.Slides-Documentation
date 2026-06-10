---
title: Licencelés
type: docs
weight: 50
url: /hu/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Az Aspose.Slides for JasperReports egy időkorlát nélküli ingyenes értékelő verzióként érhető el a [letöltési oldalon](https://downloads.aspose.com/slides/hu/jasperreport). Az értékelő és a licencelt verzió ugyanaz a letöltés.

Ha elégedett az értékelő verzióval, [vásároljon licencet](https://purchase.aspose.com/buy). Győződjön meg arról, hogy megérti és elfogadja a felfizetési feltételeket.

A licenc a rendelés oldalon letölthető, miután a rendelés ki lett fizetve. A licenc egy egyszerű szöveges, digitálisan aláírt XML fájl, amely olyan információkat tartalmaz, mint a kliens neve, a megvásárolt termék és a licenc típusa. Ne módosítsa a licencfájl tartalmát semmilyen módon: ez érvényteleníti a licencet.

Töltse le a licencet a számítógépére, és másolja a megfelelő mappába (például az alkalmazás mappájába vagy a **JasperReports\lib** könyvtárba).

## **Értékelő Verzió Korlátozása**
Az Aspose.Slides értékelő verziója (licenc megadása nélkül) teljes termékfunkcionalitást biztosít, de (a prezentációk mentésekor) egy értékelő vízjelet helyez a diák közepére, ahogy az alábbi ábrán látható:

![todo:image_alt_text](evaluation_watermark.png) 

## **Licenc Alkalmazása**
A licenc alkalmazásának több módja van, attól függően, hogy JasperReports-szal vagy JasperServer-rel dolgozik.

### **Licenc Alkalmazása JasperReports-hez**
Használjon közvetlen setLicense metódushívást, hasonlóan az Aspose.Slides for Java-hoz.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Hozzon létre egy folyamobjektumot, amely a licencfájlt tartalmazza
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Példányosítsa a License osztályt
    License license = new License();
	
    //Állítsa be a licencet a folyamobjektumon keresztül
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Vagy állítsa be az exportáló paramétert a kódban.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Licenc Alkalmazása JasperServer-en**
Állítsa be az exportáló paramétert az applicationContext.xml-ben.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```