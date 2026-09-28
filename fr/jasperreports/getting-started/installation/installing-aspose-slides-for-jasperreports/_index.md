---
title: Installation d'Aspose.Slides pour JasperReports
type: docs
weight: 40
url: /fr/jasperreports/installing-aspose-slides-for-jasperreports/
description: "Choisissez les jars d'Aspose.Slides pour JasperReports correspondant à votre version de JasperReports, et ajoutez-les à JasperReports, à un projet Maven ou à JasperReports Server."
---
## **Choisissez les jars pour votre version JasperReports**

Aspose.Slides for JasperReports est distribué sous forme de fichier ZIP sur la [page de téléchargement](https://releases.aspose.com/slides/fr/jasperreport/). Son dossier *lib* contient un sous-dossier par plage de versions de JasperReports. Prenez les jars du sous-dossier qui correspond à la version de JasperReports que vous utilisez :

| Version JasperReports | Sous-dossier du *lib* |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

Il n'existe aucun sous-dossier pour JasperReports 6.17.0 ou ultérieur, y compris JasperReports 7. Le sous-dossier *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* ne contient aucun jar, seulement une note indiquant que la prise en charge de ces versions a pris fin dans Aspose.Slides for JasperReports 17.6.

Chaque sous-dossier contient deux jars ; *xx.x* dans leurs noms correspond à la version du produit :

- *aspose.slides.jasperreports.library-xx.x.jar* contient les exportateurs pour JasperReports Library (`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` et `ASHtmlExporter`) ainsi que la classe `License`.
- *aspose.slides.jasperreports.server-xx.x.jar* contient les actions d'exportation pour JasperReports Server. Il repose sur le jar de la bibliothèque, de sorte que le serveur a toujours besoin des deux jars du même sous-dossier.

## **Ajoutez le jar de la bibliothèque à JasperReports ou à votre application**

Copiez *aspose.slides.jasperreports.library-xx.x.jar* depuis le sous-dossier correspondant vers le dossier *lib* de JasperReports ou vers le classpath de votre application. Votre application pourra alors créer les exportateurs dans le code.

{{% alert color="info" title="Note" %}}
Sur Linux, JasperReports a besoin de fontconfig et d'au moins une police installée pour remplir un rapport. Sans polices, le remplissage échoue avec l'erreur "Error initializing graphic environment".
{{% /alert %}}

## **Ajoutez le jar de la bibliothèque à un projet Maven**

Le jar se trouve dans le ZIP plutôt que dans un dépôt Maven. Pour l'utiliser dans une construction Maven, installez-le dans votre dépôt Maven local. Pour la version 26.6, exécutez cette commande dans le dossier contenant le jar :

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

Ajoutez-le ensuite aux dépendances dans *pom.xml*, avec une version de JasperReports couverte par le sous-dossier du jar :

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

Les identifiants group et artifact sont ceux que vous avez choisis dans la commande d'installation ; ils doivent simplement correspondre. Un projet complet qui utilise JasperReports 6.16.0 se trouve dans [Votre première exportation](/slides/fr/jasperreports/#your-first-export).

## **Ajoutez les jars à JasperReports Server**

Copiez les deux jars depuis le sous-dossier correspondant vers le dossier *WEB-INF/lib* de l'application web JasperReports Server, puis enregistrez les exportateurs comme décrit dans [Intégration avec JasperServer](/slides/fr/jasperreports/integration-with-jasperserver/).