---
title: Instalando la licencia de Aspose.Slides para SharePoint
type: docs
weight: 10
url: /es/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "Instala la licencia de Aspose.Slides para SharePoint en una granja de SharePoint: añade la solución de licencia al almacén de soluciones, implántala y verifica que los archivos convertidos ya no llevan la marca de agua de evaluación."
---
{{% alert color="info" title="Note" %}}

Una vez que estés satisfecho con tu evaluación, puedes [comprar una licencia](https://purchase.aspose.com/pricing/slides/sharepoint/). Antes de comprar, asegúrate de comprender y aceptar los términos de suscripción de la licencia. La licencia se envía por correo electrónico cuando el pedido ha sido pagado.

La licencia es un archivo ZIP que contiene un paquete de solución regular de SharePoint. El archivo contiene:

- Aspose.Slides.SharePoint.License.wsp – el archivo del paquete de solución de SharePoint. La licencia se empaqueta como una solución de SharePoint para facilitar el despliegue y la retirada en una granja de servidores.
- readme.txt – instrucciones de instalación de la licencia.

{{% /alert %}}

## **Deploying the License**

La instalación de la licencia se realiza desde la consola del servidor mediante **stsadm.exe**.

{{% alert color="info" title="Note" %}}

Se omiten las rutas en la siguiente sección para mayor claridad.

{{% /alert %}}

Realiza los siguientes pasos para desplegar la licencia de Aspose.Slides for SharePoint:

1. Ejecuta stsadm para añadir la solución al almacén de soluciones de SharePoint:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. Despliega la solución en todos los servidores de la granja:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. Ejecuta los trabajos de temporizador administrativos para completar el despliegue de inmediato:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

La operación `addsolution` recibe la ruta del archivo de solución en `-filename`; la operación `deploysolution` recibe el nombre de la solución que ya está en el almacén en `-name`.

{{% alert color="info" title="Note" %}}

Recibirás una advertencia al ejecutar el paso de despliegue si el servicio de Administración de SharePoint no está en ejecución. **stsadm.exe** depende de este servicio y del servicio de Temporizador de SharePoint para replicar los datos de la solución en toda la granja. Si estos servicios no están en ejecución en tu granja de servidores, puede que necesites desplegar la licencia en cada servidor.

{{% /alert %}}

{{% alert color="info" title="Note" %}}

En SharePoint 2010 y versiones posteriores, los cmdlets de SharePoint Management Shell `Add-SPSolution`, `Install-SPSolution` y `Start-SPAdminJob` corresponden a las operaciones `addsolution`, `deploysolution` y `execadmsvcjobs`. Consulta [Correspondencia de Stsadm a Microsoft PowerShell en SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).

{{% /alert %}}

## **Test the License**

Para comprobar que la licencia se ha instalado correctamente, convierte cualquier presentación a un nuevo formato. Si no aparece la marca de agua de evaluación en el archivo convertido, la licencia está activa.