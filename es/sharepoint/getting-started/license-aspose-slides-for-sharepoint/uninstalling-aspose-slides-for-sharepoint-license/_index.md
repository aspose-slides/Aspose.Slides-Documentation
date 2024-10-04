---
title: Desinstalación de la licencia de Aspose.Slides para SharePoint
type: docs
weight: 20
url: /sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---

Para desinstalar la licencia, utilice los pasos a continuación desde la consola del servidor. 

1. Retire la solución de licencia de la granja: 

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. Ejecute trabajos de temporizador administrativos para completar la retractación inmediatamente: 

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. Espere a que se complete la retractación. Puede usar la Administración Central para verificar si la retractación se completó en **Administración Central**, luego **Operaciones** y **Administración de Soluciones**.
4. Elimine la solución de la tienda de soluciones de SharePoint: 

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```