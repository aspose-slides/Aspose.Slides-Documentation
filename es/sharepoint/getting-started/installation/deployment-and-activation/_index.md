---
title: Implementación y Activación
type: docs
weight: 20
url: /es/sharepoint/deployment-and-activation/
---

## **Implementación**
Durante la implementación, Aspose.Slides para SharePoint: 

- Instala el **Aspose.Slides.SharePoint.dll** en el Global Assembly Cache y añade una entrada SafeControl al archivo **web.config**.
- Instala el manifiesto de características y otros archivos necesarios en los directorios apropiados.
- Registra la característica en la base de datos de SharePoint y la hace disponible para activación a nivel de característica.
## **Activación**
Aspose.Slides para SharePoint se empaqueta como una característica a nivel de sitio (colección de sitios) y puede ser activada o desactivada en colecciones de sitios. Durante la activación, la característica realiza algunos cambios en el directorio virtual de la aplicación web principal de la colección de sitios. Esto: 

- Añade la página de configuraciones de conversión al archivo del mapa del sitio.
- Copia los archivos de recurso necesarios a la carpeta App_GlobalResources en el directorio virtual.