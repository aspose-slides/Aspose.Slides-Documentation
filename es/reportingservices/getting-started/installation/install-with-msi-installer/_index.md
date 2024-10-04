---
title: Instalar con el instalador MSI
type: docs
weight: 20
url: /reportingservices/install-with-msi-installer/
---

## **Instalación**
Puedes instalar Aspose.Slides para Reporting Services a través de un instalador MSI. 

{{% alert title="Nota" color="warning" %}} 

**Aspose.Slides para Reporting Services** requiere la instalación de **.NET Framework 3.5** en la máquina host. 

{{% /alert %}}

Ejecuta ***Aspose.Slides.ReportingServices.msi*** y sigue los pasos que ofrece el instalador. 

El instalador copiará el ensamblado y otros archivos al directorio especificado e instalará el producto en la instancia predeterminada de Reporting Services. No necesitas copiar ni modificar archivos manualmente a menos que desees agregar parámetros de configuración especiales. 

La instalación mediante el instalador MSI es la mejor opción en la mayoría de los casos. Sin embargo, es posible que desees instalar el producto manualmente en algunas situaciones: 

- La instalación automática falla debido a problemas de seguridad u otras razones. 
- El producto debe instalarse en una instancia nombrada (no predeterminada) de Reporting Services o en múltiples instancias.
- Después de actualizar a la última versión, solo deseas reemplazar el ensamblado en lugar de desinstalar la versión antigua e instalar la nueva utilizando el instalador MSI. **Nota** que podrías terminar con otros archivos en este caso.