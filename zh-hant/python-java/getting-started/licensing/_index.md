---
title: 授權
type: docs
weight: 80
url: /zh-hant/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- 授權檔案
- 暫時授權
- 計量授權
- 評估限制
description: "在 Aspose.Slides for Python via Java 中套用檔案、位元組或計量授權，並從您的應用程式中移除評估限制。"
---
## **概觀**

Aspose.Slides for Python via Java 可以在評估模式或授權模式下執行。在評估模式下，它會在每個儲存的簡報的每張投影片上加入評估浮水印文字方塊，並截斷程式碼從簡報讀取的文字。本文說明如何從檔案或位元組套用授權，以及如何設定計量授權。

如需購買方案，請參閱[定價資訊](https://purchase.aspose.com/pricing/slides/zh-hant/family)。如需一般授權與購買問題，請參閱[購買政策與常見問題](https://purchase.aspose.com/policies)。

有關評估限制及如何請求暫時授權，請參閱[評估 Aspose.Slides](/slides/zh-hant/python-java/evaluate-aspose-slides/)。暫時授權的套用方式與購買授權檔案相同。

## **關於授權**

授權檔案包含產品名稱、授權開發人員數量、以及訂閱到期日等資訊。該檔案為以數位簽章的 XML。

{{% alert color="warning" title="警告" %}}
請勿編輯授權檔案。即使多一個換行也會使其數位簽章失效。
{{% /alert %}}

在應用程式或處理程序啟動時只套用一次授權，於建立簡報或執行其他 Aspose.Slides 作業之前套用。若使用授權檔案，請使用[License](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/license/)類別。計量授權則以公鑰與私鑰配對取代授權檔案。

## **套用授權**

以下範例假設已安裝 Aspose.Slides for Python via Java 及其前置需求。每個範例都是獨立腳本，會啟動 JVM、匯入 API，並套用授權。在您的應用程式中，請於套用授權後執行簡報操作，並於所有 Aspose.Slides 工作完成後再關閉 JVM。

### **從檔案套用授權**

將授權檔案路徑傳遞給[License.setLicense](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/license/#setLicense)。將 `Aspose.Slides.lic` 替換為您的授權檔案路徑。

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
        # 在此執行簡報操作，在關閉 JVM 之前。
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

使用完整的檔名，包含副檔名。例如，若檔名為 `Aspose.Slides.lic.xml`，請在路徑中加入 `.xml`。使用絕對路徑可避免應用程式工作目錄的歧義。

範例使用[License.isLicensed](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/license/#isLicensed)來檢查授權是否已套用。

### **從位元組套用授權**

當授權以 Python 位元組形式提供時，請使用[License.setLicenseFromBytes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/license/#setLicenseFromBytes)。以下範例以二進位模式讀取檔案，並在套用授權前關閉檔案。

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
        # 在此執行簡報操作，在關閉 JVM 之前。
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

保持原始位元組不變。套用前請勿解碼、重新格式化或以其他方式修改授權內容。

## **套用計量授權**

計量授權會根據 API 使用量計費。取得計量授權後，請使用[Metered.setMeteredKey](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/metered/#setMeteredKey)套用其公鑰與私鑰。於應用程式啟動時初始化[Metered](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/metered/)物件，並一次性套用金鑰。

以下範例從環境變數 `ASPOSE_METERED_PUBLIC_KEY` 與 `ASPOSE_METERED_PRIVATE_KEY` 讀取金鑰。請在執行腳本前設定這兩個變數。

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
        # 在此執行簡報操作，在關閉 JVM 之前。
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="注意" %}}
計量授權需要網際網路連線以驗證金鑰並回報使用情況。請將私鑰保留在程式碼與日誌之外。詳情請參閱[計量授權常見問答](https://purchase.aspose.com/faqs/licensing/metered) ，以了解連線與計費資訊。
{{% /alert %}}

## **常見問題**

**購買授權後，我需要安裝不同的套件嗎？**

不需要。請對您在評估時使用的相同套件套用授權。

**我需要為每個簡報都套用授權嗎？**

不需要。請在應用程式啟動時一次套用，於建立或載入簡報之前。

**我可以重新命名授權檔案嗎？**

可以。請在程式碼中使用新的完整檔名，且保持檔案內容不變。

**我可以在基於位元組的範例中使用暫時授權嗎？**

可以。請以位元組方式讀取暫時授權檔案，並以與購買授權相同的方式套用。