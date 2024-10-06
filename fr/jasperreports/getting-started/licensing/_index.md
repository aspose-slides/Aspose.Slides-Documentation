---
title: Licences
type: docs
weight: 50
url: /jasperreports/licensing/
---

{{% alert color="primary" %}} 

Aspose.Slides pour JasperReports est disponible en tant qu'évaluation gratuite à durée illimitée depuis la [page de téléchargement](https://downloads.aspose.com/slides/jasperreport). Les versions d'évaluation et sous licence du produit sont le même téléchargement.

Lorsque vous êtes satisfait de l'évaluation, [achetez une licence](https://purchase.aspose.com/buy). Assurez-vous de comprendre et d'accepter les conditions d'abonnement.

La licence est disponible en téléchargement depuis la page de commande après que la commande ait été payée. La licence est un fichier XML en texte clair, signé numériquement, qui contient des informations telles que le nom du client, le produit acheté et le type de licence. Ne modifiez en aucun cas le contenu du fichier de licence : le faire invalide la licence.

Téléchargez la licence sur votre ordinateur et copiez-la dans le dossier approprié (par exemple votre dossier d'application ou **JasperReports\lib**).

## **Limitation de la Version d'Évaluation**
La version d'évaluation d'Aspose.Slides (sans licence spécifiée) fournit l'intégralité des fonctionnalités du produit, mais (lorsque vous enregistrez vos présentations) elle injecte un filigrane d'évaluation au centre de chaque diapositive comme montré dans la figure ci-dessous :

![todo:image_alt_text](evaluation_watermark.png) 

## **Application d'une Licence**
Il existe plusieurs façons d'appliquer une licence, selon que vous travaillez sur JasperReports ou JasperServer.

### **Application d'une Licence pour JasperReports**
Utilisez un appel direct à la méthode setLicense similaire à Aspose.Slides pour Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Créer un objet stream contenant le fichier de licence
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Instancier la classe License
    License license = new License();
	
    //Définir la licence via l'objet stream
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Ou, définissez le paramètre de l'exportateur dans le code.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Application d'une Licence sur JasperServer**
Définissez le paramètre de l'exportateur dans le applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```