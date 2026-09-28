---
title: Configuration des démos
type: docs
weight: 70
url: /fr/jasperreports/demos-setup/
description: "Configurez les projets de démonstration à partir du téléchargement d'Aspose.Slides for JasperReports, modifiez la classe d'exportation qu'ils utilisent et compilez-les avec Ant."
---
## **À quoi servent les démos**

Le dossier *samples* du téléchargement d'Aspose.Slides for JasperReports contient huit projets de démonstration : *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text* et *xmldatasource*. Ce sont des démonstrations standard de JasperReports, modifiées pour ajouter une cible de construction `ppt` qui exporte le rapport rempli au format PPT. Le téléchargement ne contient aucune présentation exportée ; vous les créez en construisant une démo.

## **Modifier la classe d'exportation avant de compiler**

Tel qu’il est fourni, le code Java des démos utilise `com.aspose.slides.jasperreports.JRPptExporter`, une classe qui n’est pas présente dans les jars actuels, ce qui empêche la compilation des démos. Dans la classe d’application de la démo (par exemple, *ShapesApp.java* dans la démo *shapes*), remplacez `JRPptExporter` par `ASPptExporter`, l’exportateur PPT du même package. La démo *fonts* importe l’ensemble du package, donc seul le nom de la classe dans son code change.

Les démos utilisent également des classes JasperReports qui ont été supprimées dans les versions ultérieures de JasperReports, comme `JExcelApiExporter` et `JRExporterParameter.FONT_MAP`. Avec la modification ci‑dessus, les démos se compilent comme suit :

| Version JasperReports | Démos qui se compilent |
| :- | :- |
| 5.5.1 | les huit |
| 5.5.2 et 6.4.0 | *charts*, *images*, *landscape*, *shapes* et *xmldatasource* |
| 6.16.0 | *charts* |

## **Construire une démo**

Le *build.xml* de chaque démo s’attend à la structure de dossiers d’un projet JasperReports : il compile en se basant sur *../../../build/classes* et les jars situés dans *../../../lib*, relatifs au dossier de la démo.

1. Copiez le dossier de la démo dans *demo/samples* de votre dossier de projet JasperReports.  
2. Copiez *aspose.slides.jasperreports.library-xx.x.jar* depuis le sous‑dossier *lib* du téléchargement correspondant à votre version de JasperReports vers le dossier *lib* du projet JasperReports. Voir [Installation d'Aspose.Slides pour JasperReports](/slides/fr/jasperreports/installing-aspose-slides-for-jasperreports/).  
3. Placez le jar de votre version de JasperReports ainsi que les jars dont il dépend dans le même dossier *lib*. En plus des fichiers de la démo, *build.xml* ne met sur le classpath que *build/classes* et les jars du *lib*, et *build/classes* ne contient les classes JasperReports qu’après que vous ayez compilé JasperReports à partir du code source.  
4. Les démos *charts*, *subreport* et *text* lisent la base de données d’exemple HSQLDB de JasperReports (`jdbc:hsqldb:hsql://localhost`), donc démarrez d’abord son serveur, comme décrit dans *samples/Readme.txt* du téléchargement. Les autres démos n’ont pas besoin de base de données.  
5. Dans le dossier de la démo, compilez l’application, compilez le design du rapport, remplissez‑le et exportez‑le au format PPT :

```bash
ant javac
ant compile
ant fill
ant ppt
```

La cible `ppt` écrit la présentation à côté du rapport rempli, en le nommant d’après le rapport (par exemple, *LandscapeReport.ppt*).

Deux démos nécessitent plus que les étapes ci‑dessus :

- La démo *images* charge une image depuis `http://jasperreports.sourceforge.net/jasperreports.png` lors de l’exportation. Cette adresse redirige maintenant vers HTTPS, de sorte que l’étape `ppt` n’écrit aucune présentation tant que vous ne modifiez pas l’adresse en `https://` dans *ImagesReport.jrxml*. Avec JasperReports 6.4.0, l’exportation de cette image échoue même en HTTPS.  
- Le rapport *xmldatasource* utilise la police Arial. Sur un système ne contenant pas Arial, `ant fill` indique que la police « is not available to the JVM » et n’écrit aucun rapport rempli, de sorte que `ant ppt` n’a rien à exporter. La construction indique néanmoins la réussite, il faut donc vérifier la sortie de chaque étape.