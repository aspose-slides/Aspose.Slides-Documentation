---
title: Licensing
type: docs
weight: 80
url: /python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- license file
- temporary license
- metered licensing
- evaluation limitations
description: "Apply a file, byte-based, or metered license in Aspose.Slides for Python via Java and remove evaluation limitations from your applications."
---

## **Overview**

Aspose.Slides for Python via Java can run in evaluation mode or with a license. This article explains how to apply a license from a file or bytes and how to configure metered licensing.

For purchase options, see [Pricing Information](https://purchase.aspose.com/pricing/slides/family). For general licensing and purchasing questions, see [Purchase Policies and FAQ](https://purchase.aspose.com/policies).

For evaluation limitations and how to request a temporary license, see [Evaluate Aspose.Slides](/slides/python-java/evaluate-aspose-slides/). Apply a temporary license in the same way as a purchased license file.

## **About the License**

A license file contains information such as the product name, the number of licensed developers, and the subscription expiry date. The file is digitally signed XML.

{{% alert color="warning" title="Warning" %}}

Do not edit the license file. Even an extra line break can invalidate its digital signature.

{{% /alert %}}

Apply the license once per application or process, before creating presentations or performing other Aspose.Slides operations. For a license file, use the [License](https://reference.aspose.com/slides/python-java/aspose.slides/license/) class. Metered licensing uses a public and private key pair instead of a license file.

## **Apply a License**

The following examples assume that Aspose.Slides for Python via Java and its prerequisites are installed. Each example is a standalone script that starts the JVM, imports the API, and applies a license. In your application, perform your presentation operations after applying the license and shut down the JVM only after all Aspose.Slides work is complete.

### **Apply a License from a File**

Pass the license file path to [License.setLicense](https://reference.aspose.com/slides/python-java/aspose.slides/license/#setLicense). Replace `Aspose.Slides.lic` with the path to your license file.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # Perform presentation operations here, before shutting down the JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Use the exact file name, including its extension. For example, if the file is named `Aspose.Slides.lic.xml`, include `.xml` in the path. An absolute path avoids ambiguity about the application's working directory.

The example uses [License.isLicensed](https://reference.aspose.com/slides/python-java/aspose.slides/license/#isLicensed) to check whether the license has been applied.

### **Apply a License from Bytes**

Use [License.setLicenseFromBytes](https://reference.aspose.com/slides/python-java/aspose.slides/license/#setLicenseFromBytes) when the license is available as Python bytes. The following example reads the file in binary mode and closes it before applying the license.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # Perform presentation operations here, before shutting down the JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Keep the original bytes unchanged. Do not decode, reformat, or otherwise modify the license content before applying it.

## **Apply a Metered License**

Metered licensing bills you according to API usage. After obtaining a metered license, apply its public and private keys with [Metered.setMeteredKey](https://reference.aspose.com/slides/python-java/aspose.slides/metered/#setMeteredKey). Initialize the [Metered](https://reference.aspose.com/slides/python-java/aspose.slides/metered/) object and apply the keys once at application startup.

The following example reads the keys from the `ASPOSE_METERED_PUBLIC_KEY` and `ASPOSE_METERED_PRIVATE_KEY` environment variables. Set both variables before running the script.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # Perform presentation operations here, before shutting down the JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}

Metered licensing requires an Internet connection to validate the keys and report usage. Keep the private key out of source code and logs. See the [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) for connectivity and billing details.

{{% /alert %}}

## **FAQ**

**Do I need to install a different package after purchasing a license?**

No. Apply the license to the same package you used for evaluation.

**Should I apply a license for every presentation?**

No. Apply it once during application startup, before creating or loading presentations.

**Can I rename the license file?**

Yes. Use the exact new file name in your code and keep the file contents unchanged.

**Can I use a temporary license with the byte-based example?**

Yes. Read the temporary license file as bytes and apply it in the same way as a purchased license.
