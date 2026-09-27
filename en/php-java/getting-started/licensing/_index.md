---
title: Licensing
type: docs
weight: 80
url: /php-java/licensing/
keywords:
- license
- temporary license
- set license
- use license
- validate license
- license file
- evaluation version
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Apply, manage, and troubleshoot licenses in Aspose.Slides for PHP via Java. Ensure uninterrupted access to full features with our step-by-step licensing guide."
---

## **Introduction**

Sometimes, for the best evaluation outcomes, a hands-on approach might be needed. For this reason, Aspose.Slides provides different purchase plans and also offers a Free Trial and a 30-day Temporary License for evaluation.

{{% alert color="info" title="Note" %}}

Note that there are a number of general policies and practices that guide you on how to evaluate, properly license, and purchase our products. You can find them in the ["Purchase Policies and FAQ"](https://purchase.aspose.com/policies) section.

{{% /alert %}}

## **Evaluate Aspose.Slides**
You can easily download Aspose.Slides for evaluation. The evaluation package is the same as the purchased package. The evaluation version simply becomes licensed after you add a few lines of code to apply the license. 

## **Evaluation Version Limitation**
The evaluation version of Aspose.Slides (without a license specified) provides the full product functionality, with two limitations:

* It adds an evaluation watermark text box to the middle of every slide of each presentation it saves.
* Text that your code reads from a presentation is truncated to its first few characters, followed by a notice about the evaluation limitation. Text that your code writes is saved in full.

{{% alert color="info" title="Note" %}}

If you want to test Aspose.Slides without the evaluation version limitations, you can request a **30 Day Temporary License**. Please refer to [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) for more information.

{{% /alert %}} 

## **About the License**
You can easily download an evaluation version of Aspose.Slides for PHP via Java from its [download page](https://packagist.org/packages/aspose/slides). The evaluation version provides absolutely **the same capabilities** as the licensed version of Aspose.Slides. Furthermore, the evaluation version simply becomes licensed after you purchase a license and add a couple of lines of code to apply the license.

The license is a plain-text XML file that contains details such as the product name, number of developers it is licensed to, subscription expiry date, and so on. The file is digitally signed, so do not modify the file. Even an inadvertent addition of an extra line break to the contents of the file will invalidate it.

To avoid the limitations associated with the evaluation version, you need to set a license before using **Aspose.Slides**. You are only required to set a license once per application or process.

{{% alert color="info" title="Note" %}}

You may want to see [Metered Licensing](/slides/php-java/metered-licensing/).

{{% /alert %}} 

## **Purchased License**

After purchase, you need to apply the license file or stream. 

{{% alert color="info" title="Note" %}}

You need to set the license:
* only once per application domain
* before using any other Aspose.Slides classes

{{% /alert %}}

{{% alert color="info" title="Note" %}}

You can find pricing information on the [“Pricing Information”](https://purchase.aspose.com/pricing/slides/family) page.

{{% /alert %}}

### **Set a License in Aspose.Slides for PHP via Java**

Licenses can be applied from these locations:

* Explicit path
* Stream
* As a Metered License – a new licensing mechanism

{{% alert color="info" title="Note" %}}

Use the **setLicense** method to license a component.

While multiple calls to **setLicense** aren't harmful, they are a waste of resources (processor).

{{% /alert %}}

{{% alert color="warning" title="Warning" %}}

New licenses can activate Aspose.Slides only with version 21.4 or later. Earlier versions use a different licensing system and will not recognize these licenses.

{{% /alert %}}

#### **Apply a License Using a File**

This code snippet is used to set a license file:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense(__DIR__ . "/Aspose.Slides.lic");
```

The sample expects the license file next to the script and passes its absolute path: Aspose.Slides runs inside Tomcat, so it does not resolve a relative path against your script's folder. When calling the setLicense method, the license name should be same as that of your license file. For example, you can change the license file name to "Aspose.Slides.lic.xml". Then, in your code, you have to pass the new license name (Aspose.Slides.lic.xml) to the setLicense method.

#### **Apply a License from a Stream**

This code snippet is used to apply a license from a stream:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/lib/aspose.slides.php");

use aspose\slides\License;

$stream = new Java("java.io.FileInputStream", __DIR__ . "/Aspose.Slides.lic");

$license = new License();
$license->setLicense($stream);

$stream->close();
```

## **FAQ**

### Can I apply the license in a completely offline environment (no internet access)?

Yes. License validation is performed locally using the license file; no internet connection is required.

### What happens after the one-year subscription expires? Will the library stop working?

No. The license is perpetual: you can continue using versions released before your subscription end date; you just won’t be eligible to use newer releases without renewing.
