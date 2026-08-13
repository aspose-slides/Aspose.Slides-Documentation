---
title: Licencelés
type: docs
weight: 50
url: /hu/jasperreports/licensing/
---
{{% alert color="info" %}} 

Aspose.Slides for JasperReports ingyenes, korlátlan idejű értékelő változatként érhető el a [letöltési oldalon](https://downloads.aspose.com/slides/hu/jasperreport). Az értékelő és licencelt verziók ugyanarról a letöltésről származnak.

Ha elégedett vagy az értékelő változattal, [vásárolj licencet](https://purchase.aspose.com/buy). Győződj meg róla, hogy megérted és egyetértesz a feliratkozási feltételekkel.

A licenc az order page‑ről tölthető le, miután a rendelés ki lett fizetve. A licenc egy tiszta szövegű, digitálisan aláírt XML fájl, amely információkat tartalmaz, például a kliens nevét, a megvásárolt terméket és a licenc típusát. Ne módosítsd semmilyen módon a licencfájl tartalmát: ez érvényteleníti a licencet.

Töltsd le a licencet a számítógépedre, és másold a megfelelő mappába (például az alkalmazásod mappájába vagy a **JasperReports\lib** könyvtárba).
{{% /alert %}}

## **Értékelő verzió korlátozása**
Az Aspose.Slides értékelő verziója (licenc megadása nélkül) teljes termékfunkcionalitást biztosít, de (amikor mented a prezentációkat) egy értékelő vízjelet helyez el minden dia közepén, ahogyan az alábbi ábrán látható:

![todo:image_alt_text](evaluation_watermark.png) 

## **Licenc alkalmazása**
Többféleképpen lehet licencet alkalmazni, attól függően, hogy JasperReports‑on vagy JasperServer‑en dolgozol.

### **Licenc alkalmazása JasperReports‑hez**
Használj közvetlen setLicense metódushívást, hasonlóan az Aspose.Slides for Java‑hoz.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Hozzon létre egy stream objektumot, amely a licencfájlt tartalmazza
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Példányosítsa a License osztályt
    License license = new License();
	
    //Állítsa be a licencet a stream objektumon keresztül
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

### **Licenc alkalmazása JasperServer‑en**
Állítsd be az exporter paramétert az applicationContext.xml‑ben.

```xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```